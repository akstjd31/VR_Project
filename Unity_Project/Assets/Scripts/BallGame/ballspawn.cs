using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball,spawnPoint.transform);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
