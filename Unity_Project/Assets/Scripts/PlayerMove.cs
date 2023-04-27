using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FUNITURE
{
    CUBE = 0
}
public class PlayerMove : MonoBehaviour
{
    public Transform player;
    public Vector3 SceenCenter;
    public Image PointerGaugeImage;
    public Material mat;
    public Funiture[] funitures;
    private GameObject colObj;
    private float GaugeTimer;
    public float speed = 3;

    public Text textMessage;

    private bool isMove = false;
    private bool isFull = false;

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

        // 나중에 가구는 추가되면 해당 가구가 어떤 가구인지 판별 후에 인덱스 값 결정 (ex. Upper(hit.collider.gameObject.name) == FUNITURE.CUBE))
        if (Physics.Raycast(ray, out hit, 500.0f) && hit.collider.gameObject.CompareTag("Object"))
        {
            // 해당 오브젝트(가구)의 이름 세팅
            funitures[(int)FUNITURE.CUBE].SetText(textMessage);
            textMessage.color = Color.red;
            GaugeTimer += 1.0f / 3.0f * Time.deltaTime;
            if (GaugeTimer >= 1.0f)
            {
                // 오브젝트를 해당 가구의 색상에 매핑한 것으로 변경
                colObj = hit.collider.gameObject;
                hit.collider.gameObject.GetComponent<Renderer>().material = mat;
                //hit.transform.gameObject.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                    isFull = true;

                if (isFull && Input.GetMouseButtonUp(0))
                {
                    // 가구 상호작용
                    funitures[(int)FUNITURE.CUBE].Interaction(colObj);
                    isFull = false;
                }  
            }
        }

        else
        {
            // 만약 가구를 바라보고 있지 않다면, 마지막으로 본 가구의 기본 머티리얼로 설정.
            if (colObj != null) colObj.gameObject.GetComponent<Renderer>().material = funitures[(int)FUNITURE.CUBE].SetOriginMaterial();
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
}
