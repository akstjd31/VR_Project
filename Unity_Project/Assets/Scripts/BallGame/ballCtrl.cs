using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballCtrl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -15)
        {
            DataManager.Instance.LoadGameData();
            PlayerManager.Instance.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Coin")){
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
