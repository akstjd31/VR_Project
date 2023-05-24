using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillow : Funiture
{
    private bool isOpened = false;
    public override Color ChangetheColor()
    {
        return Color.red;
    }

    public override void Interaction()
    {
        // 배게를 y축 기준으로 포지션 변경.
        if (!isOpened)
        {
            StartCoroutine(Up_And_Down());
        }
            
        else
        {
            if (PlayerManager.Instance.fadeText.GetComponent<Text>().text != "isOpened!")
                PlayerManager.Instance.fadeText.GetComponent<Text>().text = "isOpened!";
            StartCoroutine(PlayerManager.Instance.FadeTextToZero(PlayerManager.Instance.fadeText.GetComponent<Text>()));
        }
    }

    IEnumerator Up_And_Down()
    {
        isOpened = true;
        this.transform.position = new Vector3(this.transform.position.x,
                                              this.transform.position.y + 1.0f,
                                              this.transform.position.z);
        
        yield return new WaitForSeconds(delayTime);
        this.transform.position = new Vector3(this.transform.position.x,
                                              this.transform.position.y - 1.0f,
                                              this.transform.position.z);
        isOpened = false;
    }
}
