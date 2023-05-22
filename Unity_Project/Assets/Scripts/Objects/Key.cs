using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Funiture
{
    public override Color ChangetheColor()
    {
        return Color.magenta;
    }

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (!flag)
        {
            PlayerManager.Instance.count++;
            Destroy(obj);
            return true;
        }
        return false;
    }
}