using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dresser_Closet : Funiture
{
    private bool isOpened = false;
    public override Color ChangetheColor()
    {
        return Color.yellow;
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
        switch (this.name) {
            case "Closet_Door_L":
                this.transform.GetComponent<Animator>().Play("Opening");
                yield return new WaitForSeconds(delayTime);
                this.transform.GetComponent<Animator>().Play("Closing");
                break;
            default:
                this.transform.GetComponent<Animator>().Play("Opening 1");
                yield return new WaitForSeconds(delayTime);
                this.transform.GetComponent<Animator>().Play("Closing 1");
                break;
        }
        isOpened = false;
    }
}
