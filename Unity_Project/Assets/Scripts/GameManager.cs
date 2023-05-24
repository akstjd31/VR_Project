using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject main;
    public GameObject mainCam;
    public Vector3 mainCamRot;

    private static GameManager instance = null;
    

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    { 
        // 기존 메인에 존재하는 플레이어의 좌표를 기억
        mainCam = main.transform.Find("Player").Find("Main Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamRot =  mainCam.transform.rotation.eulerAngles;
    }
}
