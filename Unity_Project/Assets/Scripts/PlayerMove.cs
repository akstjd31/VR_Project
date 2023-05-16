using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


////////////////////////////////////////////////////////
////// **** 주의 사항 ****
////// 1. 가구의 집합(배열)의 인덱스와 가구 이넘 클래스의 번호가 일치해야 함.
////// 2. 상호작용 할 가구에는 Object라는 태그와 해당 작성된 스크립트, 가구 배열에 넣기
////// 3. 가구이름 비교하는 것이 존재하므로, 해당 가구명을 변경하여 프리팹 새로 설정하기 (단, 머티리얼, 콜라이더가 존재하는 오브젝트)


// 가구 이넘 클래스
public enum OBJECTS
{
    PILLOW = 0,
    DRAWERTABLE_TOP, DRAWERTABLE_BOTTOM,
    COMPUTER_TABLE_L, COMPUTER_TABLE_R_TOP, COMPUTER_TABLE_R_BOTTOM,
    WASHSTAND_DRAWER_01, WASHSTAND_DRAWER_02, WASHSTAND_DRAWER_03, WASHSTAND_DOOR_01, WASHSTAND_DOOR_02,
    BROILER_DOOR, OVEN_DOOR,
    DRESSER_CLOSET_DOOR_L, DRESSER_CLOSET_DOOR_R,
    KEY_01
}

public class PlayerMove : MonoBehaviour
{
    public Transform player;
    public Vector3 SceenCenter;
    public Image PointerGaugeImage;
    public Material mat; // Shader : Unlit/Color
    public Funiture[] funitures; // 가구들을 담은 배열
    private bool[] funitures_check; // 가구들의 상호작용 체크
    // private Dictionary<string, bool> funiture_check;
    public Text textMessage, keyCountText;
    private GameObject origin_obj;
    [SerializeField] private Material origin_col_obj_mat; // 기존 상호작용이 가능한 오브젝트의 머티리얼을 저장.

    public float speed = 3;
    [SerializeField] private int count = 0;
    private float GaugeTimer;
    private float dist;

    private bool isMove = false; // 움직일 수 있는 상태를 나타내는 변수
    private bool isFull = false; // 게이지가 완전히 채워졌는지 확인하는 변수
    private bool mat_check = false; // 해당 오브젝트의 색상을 초반에 한번만 저장해놓기 위한 변수

    private string obj_nm;
    private int curIdx, pastIdx;

    // Start is called before the first frame update
    void Start()
    {
        SceenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        funitures_check = new bool[funitures.Length];

        for (int i = 0; i < funitures.Length; i++)
            funitures_check[i] = false;

        pastIdx = -1;
    }

    // Update is called once per frame
    void Update()
    {
        keyCountText.text = "Key: " + count;
        
        Ray ray = Camera.main.ScreenPointToRay(SceenCenter);
        RaycastHit hit; 
        //Physics.Raycast(player.transform.position, player.forward, out hit, 10);
        PointerGaugeImage.fillAmount = GaugeTimer;
        // 나중에 가구는 추가되면 해당 가구가 어떤 가구인지 판별 후에 인덱스 값 결정
        if (Physics.Raycast(ray, out hit, 500.0f) && hit.collider.gameObject.CompareTag("Object"))
        {
            dist = Vector3.Distance(hit.collider.gameObject.transform.position, this.transform.position);
            if (pastIdx == -1 || pastIdx != curIdx)
            {
                pastIdx = curIdx;
                GaugeTimer = 0.0f;
            }

            // 만약, 해당 오브젝트를 바라보다가 else문으로 넘어가지 않고 바로 다른 오브젝트를 바라보는 경우, 기존 머티리얼 적용. (중요)
            if (origin_obj != null) 
            {
                origin_obj.GetComponent<Renderer>().material = origin_col_obj_mat;
            }

            // 가구를 처음으로 바라봤으며 처음 1번만 기록
            if (origin_col_obj_mat == null || !mat_check)
            {
                origin_col_obj_mat = hit.collider.gameObject.GetComponent<Renderer>().material;
                mat_check = true;
            }

            // 현재 가구의 인덱스를 저장.
            curIdx = CheckObjectIndex(hit.collider.gameObject);

            if (pastIdx == -1)
                pastIdx = curIdx;

            // 해당 오브젝트(가구)의 이름 세팅
            textMessage.text = funitures[curIdx].GetName();
            mat.color = funitures[curIdx].ChangetheColor();
            textMessage.color = Color.red;

            // 현재 오브젝트와의 거리가 3.5이내일 때 게이지 충전
            if (dist <= 3.5f)
            {
                GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
                isMove = false;
            }

            if (GaugeTimer >= 1.0f)
            {
                // 오브젝트를 해당 가구의 색상에 매핑한 것으로 변경
                origin_obj = hit.collider.gameObject;
                hit.collider.gameObject.GetComponent<Renderer>().material = mat;
                
                if (Input.GetMouseButtonDown(0))
                    isFull = true;

                if (isFull && Input.GetMouseButtonUp(0))
                {
                    // 가구 상호작용
                    funitures_check[curIdx] = funitures[curIdx].Interaction(origin_obj, funitures_check[curIdx]);
                    origin_obj.GetComponent<Renderer>().material = origin_col_obj_mat;

                    isFull = false;
                    GaugeTimer = 0.0f;
                }  
            }
        }

        else
        {

            if (origin_obj != null)
            {
                origin_obj.GetComponent<Renderer>().material = origin_col_obj_mat;
                // origin_col_obj_mat = null;
            }
            
            GaugeTimer = 0.0f;
            textMessage.text = "Touch to Move";
            textMessage.color = Color.black;
            mat_check = false;

            // 과거 인덱스 저장
            pastIdx = curIdx;

        }

        if (Input.GetMouseButtonDown(0))
        {
            isMove = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
        }

        if (isMove)
        {
            Movement();
        }
    }
    private void Movement()
    {
        Vector3 dir = player.forward;
        dir.y = 0;
        this.transform.position += dir * Time.deltaTime * speed;
    }

    // 현재 가구가 어떤 가구인지 체크
    private int CheckObjectIndex(GameObject obj)
    {
        switch (obj.name)
        {
            case "Pillow":
                return (int)OBJECTS.PILLOW;
            case "Drawer_Top":
                return (int)OBJECTS.DRAWERTABLE_TOP;
            case "Drawer_Bottom":
                return (int)OBJECTS.DRAWERTABLE_BOTTOM;
            case "Computer_Table_L":
                return (int)OBJECTS.COMPUTER_TABLE_L;
            case "Computer_Table_R_Top":
                return (int)OBJECTS.COMPUTER_TABLE_R_TOP;
            case "Computer_Table_R_Bottom":
                return (int)OBJECTS.COMPUTER_TABLE_R_BOTTOM;
            case "Washstand_Drawer_01":
                return (int)OBJECTS.WASHSTAND_DRAWER_01;
            case "Washstand_Drawer_02":
                return (int)OBJECTS.WASHSTAND_DRAWER_02;
            case "Washstand_Drawer_03":
                return (int)OBJECTS.WASHSTAND_DRAWER_03;
            case "Washstand_Door_01":
                return (int)OBJECTS.WASHSTAND_DOOR_01;
            case "Washstand_Door_02":
                return (int)OBJECTS.WASHSTAND_DOOR_02;
            case "Broiler_Door":
                return (int)OBJECTS.BROILER_DOOR;
            case "Oven_Door":
                return (int)OBJECTS.OVEN_DOOR;
            case "Closet_Door_L":
                return (int)OBJECTS.DRESSER_CLOSET_DOOR_L;
            case "Closet_Door_R":
                return (int)OBJECTS.DRESSER_CLOSET_DOOR_R;
            case "Key_01":
                return (int)OBJECTS.KEY_01;

        }
        return -1;
    }
}
