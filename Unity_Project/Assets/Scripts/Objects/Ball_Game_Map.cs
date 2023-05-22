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

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (!flag)
        {
            Destroy(this.gameObject);
            PlayerManager.Instance.gameObject.SetActive(false);
            SceneManager.LoadScene("MazeScene");
            return true;
        }
        return false;
    }
}
