using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Washstand_Drawer : Funiture
{
    public override Color ChangetheColor()
    {
        return new Color(255f/255f, 165f/255f, 0); // orange
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
