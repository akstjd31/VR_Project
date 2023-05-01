using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FUNITURE
{
    CUBE = 0, PILLOW
}

public class PlayerMove : MonoBehaviour
{
    public Transform player;
    public Vector3 SceenCenter;
    public Image PointerGaugeImage;
    public Material mat;
    public Funiture[] funitures;
    public Text textMessage;
    private GameObject origin_obj;
    [SerializeField] private Material origin_col_obj_mat; // 기존 상호작용이 가능한 오브젝트의 머티리얼을 저장.

    public float speed = 3;
    private float GaugeTimer;
    private float dist;

    private bool isMove = false;
    private bool isFull = false;
    private bool mat_check = false; // 해당 오브젝트의 색상을 초반에 한번만 저장해놓기 위한 변수

    private int idx;

    // Start is called before the first frame update
    void Start()
    {
        SceenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(SceenCenter);
        RaycastHit hit; 
        //Physics.Raycast(player.transform.position, player.forward, out hit, 10);
        PointerGaugeImage.fillAmount = GaugeTimer;
        // 나중에 가구는 추가되면 해당 가구가 어떤 가구인지 판별 후에 인덱스 값 결정
        if (Physics.Raycast(ray, out hit, 500.0f) && hit.collider.gameObject.CompareTag("Object"))
        {
            dist = Vector3.Distance(hit.collider.gameObject.transform.position, this.transform.position);
            Debug.Log(dist);
            // 가구를 처음으로 바라봤으며 처음 1번만 기록
            if (origin_col_obj_mat == null || !mat_check)
            {
                origin_col_obj_mat = hit.collider.gameObject.GetComponent<Renderer>().material;
                mat_check = true;
            }

            // 현재 가구의 인덱스를 저장.
            idx = CheckObjectIndex(hit.collider.gameObject);
            // 해당 오브젝트(가구)의 이름 세팅
            funitures[idx].SetText(textMessage);
            textMessage.color = Color.red;
            if (dist <= 3.5f) GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
            if (GaugeTimer >= 1.0f)
            {
                // 오브젝트를 해당 가구의 색상에 매핑한 것으로 변경
                origin_obj = hit.collider.gameObject;
                hit.collider.gameObject.GetComponent<Renderer>().material = mat;
                
                //hit.transform.gameObject.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                    isFull = true;

                if (isFull && Input.GetMouseButtonUp(0))
                {
                    // 가구 상호작용
                    funitures[idx].Interaction(origin_obj);
                    isFull = false;
                }  
            }
        }

        else
        {
            // 만약 가구를 바라보고 있지 않다면, 마지막으로 본 가구의 기본 머티리얼로 설정.
            if (origin_obj != null) 
            {
                origin_obj.GetComponent<Renderer>().material = origin_col_obj_mat;
                mat_check = false;
            }
            
            GaugeTimer = 0.0f;
            textMessage.text = "Touch to Move";
            textMessage.color = Color.black;
        }

        if (!isFull && Input.GetMouseButtonDown(0))
        {
            isMove = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
        }

        if (isMove)
        {

            Vector3 dir = player.forward;
            dir.y = 0;
            this.transform.position += dir * Time.deltaTime * speed;
        }
    }

    // 현재 가구가 어떤 가구인지 레이를 통한 오브젝트enum class를.
    private int CheckObjectIndex(GameObject obj)
    {
        switch (obj.name)
        {
            case "Cube":
                return (int)FUNITURE.CUBE;
            case "Pillow":
                return (int)FUNITURE.PILLOW;
        }
        return -1;
    }
}
