using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : Funiture
{

    // 기존 가구의 머터리얼이 존재하면 저장하고 있음.
    public override Color ChangetheColor()
    {
        return Color.blue;
    }

    public override void SetText(Text text)
    {
        text.text = "Cube";
    }
    public override void Interaction(GameObject obj)
    {
        Destroy(obj);
    }
}
