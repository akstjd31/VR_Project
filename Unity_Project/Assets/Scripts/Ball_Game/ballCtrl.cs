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
        if (this.gameObject.transform.position.y < -15f)
        {
            SceneManager.LoadScene("MazeScene");
        } 
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Coin")){

            // 기존 메인 씬에 저장된 플레이어의 회전 값을 그대로 가져온다.
            GameManager.Instance.mainCam.transform.rotation = Quaternion.Euler(GameManager.Instance.mainCamRot);
            PlayerManager.Instance.fadeTime = 0.0f;
            GameManager.Instance.main.SetActive(true);
            SceneManager.UnloadSceneAsync("MazeScene");
        }
    }
}
