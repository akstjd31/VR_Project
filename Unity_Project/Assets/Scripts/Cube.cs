using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : Funiture
{

    // ���� ������ ���͸����� �����ϸ� �����ϰ� ����.
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
