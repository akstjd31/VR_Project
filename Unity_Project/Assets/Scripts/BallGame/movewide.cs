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
        positionZ = this.transform.rotation.z - mainCam.transform.rotation.z * moveSpeed;
        this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x,
                                                                this.transform.rotation.y, -positionZ));
        // this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, );
        
        
        if (positionZ <= -25f) 
            positionZ = -25f;
        
        if (positionZ >= 25f)
            positionZ = 25f;
    }
}
