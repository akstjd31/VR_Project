using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Table : Funiture
{
    private bool unlock = false; // 해당 서랍이 열쇠로 인해 열렸는지 확인
    private bool isOpened = false;
    void start()
    {

    }

    public override Color ChangetheColor()
    {
        return new Color(128f / 255f, 0, 128f / 255f);
    }

    public override void Interaction()
    {
        switch (this.name)
        {
            case "Computer_Table_L":
                // 플레이어가 열쇠를 지닌 상태에서 해당 오브젝트가 잠겨있을 때
                if (!unlock && PlayerManager.Instance.count > 0)
                {
                    PlayerManager.Instance.count--;
                    unlock = true;
                }

                if (unlock && !isOpened)
                {
                    StartCoroutine(Open_And_Close());
                }
                else if (!unlock)
                {
                    PlayerManager.Instance.fadeText.GetComponent<Text>().text = "Locked!";
                    StartCoroutine(PlayerManager.Instance.FadeTextToZero(PlayerManager.Instance.fadeText.GetComponent<Text>()));
                }
                else if (isOpened)
                {
                    if (PlayerManager.Instance.fadeText.GetComponent<Text>().text != "isOpened!")
                        PlayerManager.Instance.fadeText.GetComponent<Text>().text = "isOpened!";
                    StartCoroutine(PlayerManager.Instance.FadeTextToZero(PlayerManager.Instance.fadeText.GetComponent<Text>()));
                }
                break;
            default:
                if (isOpened)
                {
                    PlayerManager.Instance.fadeText.GetComponent<Text>().text = "isOpened!";
                    StartCoroutine(PlayerManager.Instance.FadeTextToZero(PlayerManager.Instance.fadeText.GetComponent<Text>()));
                }
                else
                {
                    StartCoroutine(Open_And_Close());
                }
                break;
        }
    }

    IEnumerator Open_And_Close()
    {
        isOpened = true;
        this.transform.parent.GetComponent<Animator>().Play("openpull_01");
        yield return new WaitForSeconds(delayTime);
        this.transform.parent.GetComponent<Animator>().Play("closepush_01");
        isOpened = false;
    }
}
