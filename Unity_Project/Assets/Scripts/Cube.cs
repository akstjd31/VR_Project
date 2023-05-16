using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Funiture
{

    // ���� ������ ���͸����� �����ϸ� �����ϰ� ����.
    public override Color ChangetheColor()
    {
        return Color.blue;
    }
    
    public override bool Interaction(GameObject obj, bool flag)
    {
        return false;
        // if (flag)
        //     Destroy(obj);
    }
}
