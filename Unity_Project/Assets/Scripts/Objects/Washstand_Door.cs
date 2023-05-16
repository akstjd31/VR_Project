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

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (!flag)
        {
            // 서로 축마다 열리는 방향이 다르기 때문에 다른 애니메이션을 사용한듯?
            if (obj.name == "Washstand_Door_01")
                obj.GetComponent<Animator>().Play("Opening");
            else
                obj.GetComponent<Animator>().Play("Opening 1");
            return true;
        }
        else
        {
            if (obj.name == "Washstand_Door_01")
                obj.GetComponent<Animator>().Play("Closing");
            else
                obj.GetComponent<Animator>().Play("Closing 1");
            // StartCoroutine(closing());
            return false;
        }
    }

    // IEnumerator opening()
	// {
	// 	openandclose.Play("Opening");
	// 	yield return new WaitForSeconds(.5f);
	// }

	// IEnumerator closing()
	// {
	// 	openandclose.Play("Closing");
	// 	yield return new WaitForSeconds(.5f);
	// }
}
