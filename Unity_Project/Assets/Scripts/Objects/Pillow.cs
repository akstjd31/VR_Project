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

    public override bool Interaction(GameObject obj, bool flag)
    {
        // 배게를 y축 기준으로 포지션 변경.
        if (!flag)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 1.0f, obj.transform.position.z);
            return true;
        }
        else
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - 1.0f, obj.transform.position.z);
            return false;
        }
    }
}
