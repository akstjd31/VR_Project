using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer_Table : Funiture
{
    public override Color ChangetheColor()
    {
        return Color.green;
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
