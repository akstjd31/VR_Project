using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Table : Funiture
{

    public override Color ChangetheColor()
    {
        return new Color(128f / 255f, 0, 128f / 255f);
    }

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (!flag)
        {
            obj.transform.parent.GetComponent<Animator>().Play("openpull_01");
            return true;
        }
        else
        {
            obj.transform.parent.GetComponent<Animator>().Play("closepush_01");
            return false;
        }
    }
}
