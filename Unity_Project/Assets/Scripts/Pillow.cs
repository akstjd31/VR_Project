using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillow : Funiture
{
    public override Color ChangetheColor()
    {
        return Color.red;
    }

    public override void SetText(Text text)
    {
        text.text = "Pillow";
    }
    public override void Interaction(GameObject obj)
    {
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 1.0f, obj.transform.position.z);
    }
}
