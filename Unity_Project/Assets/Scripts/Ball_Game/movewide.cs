using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewide : MonoBehaviour
{
    public GameObject mainCam;
    private float positionZ = 0.0f;
    private float moveSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        // 맵의 z축 기준으로 회전해야 함.
        positionZ = this.transform.rotation.z - mainCam.transform.rotation.z * moveSpeed;
        this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x,
                                                                this.transform.rotation.y, -positionZ));
        
        
        // 최대, 최소 각도 조절
        if (positionZ <= -25f) 
            positionZ = -25f;
        
        if (positionZ >= 25f)
            positionZ = 25f;
    }
}
