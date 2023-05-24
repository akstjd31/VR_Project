using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer_Table : Funiture
{
    private bool isOpened = false;
    public override Color ChangetheColor()
    {
        return Color.green;
    }

    public override void Interaction()
    {
        if (!isOpened)
        {
            StartCoroutine(Open_And_Close());
        }
            
        else
        {
            if (PlayerManager.Instance.fadeText.GetComponent<Text>().text != "isOpened!")
                PlayerManager.Instance.fadeText.GetComponent<Text>().text = "isOpened!";
            StartCoroutine(PlayerManager.Instance.FadeTextToZero(PlayerManager.Instance.fadeText.GetComponent<Text>()));
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
