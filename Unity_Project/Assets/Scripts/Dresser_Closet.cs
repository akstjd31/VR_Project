using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dresser_Closet : Funiture
{
    public override Color ChangetheColor()
    {
        return Color.yellow;
    }

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (!flag)
        {
            // 서로 축마다 열리는 방향이 다르기 때문에 다른 애니메이션을 사용한듯?
            if (obj.name == "Closet_Door_L")
                obj.transform.parent.GetComponent<Animator>().Play("Opening");
            else
                obj.transform.parent.GetComponent<Animator>().Play("Opening 1");
            return true;
        }
        else
        {
            if (obj.name == "Closet_Door_L")
                obj.transform.parent.GetComponent<Animator>().Play("Closing");
            else
                obj.transform.parent.GetComponent<Animator>().Play("Closing 1");
            return false;
        }
    }
}
