using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Washstand_Door : Funiture
{

    public override Color ChangetheColor()
    {
        return new Color(255f/255f, 165f/255f, 0); // orange
    }

    public override void Interaction()
    {
        StartCoroutine(Open_And_Close());
    }

    IEnumerator Open_And_Close()
    {
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
    }
}
