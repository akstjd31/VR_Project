using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Washstand_Drawer : Funiture
{
    private bool unlock = false;
    private bool isOpened = false;

    void start()
    {
    }
    public override Color ChangetheColor()
    {
        return new Color(255f / 255f, 165f / 255f, 0); // orange
    }

    public override void Interaction()
    {

        switch (this.name)
        {
            case "Washstand_Drawer_03":
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
