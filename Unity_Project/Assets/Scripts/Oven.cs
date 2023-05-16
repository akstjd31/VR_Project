using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : Funiture
{
    public override Color ChangetheColor()
    {
        return Color.cyan;
    }

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (!flag)
        {
            switch (obj.name) {
                case "Broiler_Door":
                case "Oven_Door":
                    obj.GetComponent<Animator>().Play("OpenOven");
                    break;
            }

            return true;
        }
        else
        {
            switch (obj.name) {
                case "Broiler_Door":
                case "Oven_Door":
                    obj.GetComponent<Animator>().Play("ClosingOven");
                    break;
            
            }

            return false;
        }
    }
}
