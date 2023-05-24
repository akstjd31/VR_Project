using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Game_Map : Funiture
{
    public override Color ChangetheColor()
    {
        return new Color(138f / 255f, 43f / 255f, 226f / 255f); // blue violet
    }

    public override void Interaction()
    {

        // 해당 main씬에 존재하는 오브젝트들의 액티브를 비활성화하고 새로운 게임씬을 그대로 불러온다.
        SceneManager.LoadScene("MazeScene", LoadSceneMode.Additive);
        GameManager.Instance.main.SetActive(false);
    }
}
