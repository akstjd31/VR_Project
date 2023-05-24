using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Funiture
{
    public override Color ChangetheColor()
    {
        return Color.magenta;
    }

    public override void Interaction()
    {
        PlayerManager.Instance.count++;
        Destroy(this.gameObject);
    }
}