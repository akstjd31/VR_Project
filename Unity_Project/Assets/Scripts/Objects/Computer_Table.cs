using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Table : Funiture
{
    private bool unlock = false; // 해당 서랍이 열쇠로 인해 열렸는지 확인
    public override Color ChangetheColor()
    {
        return new Color(128f / 255f, 0, 128f / 255f);
    }

    public override bool Interaction(GameObject obj, bool flag)
    {
        if (PlayerManager.count > 0 || unlock)
        {
            if (!flag)
            {
                obj.transform.parent.GetComponent<Animator>().Play("openpull_01");

                // 좌물쇠로 잠겨있을 때만 열쇠갯수를 줄어들게 함.
                if (!unlock) PlayerManager.count--;
                unlock = true;
                return true;
            }
            else
            {
                obj.transform.parent.GetComponent<Animator>().Play("closepush_01");
                return false;
            }
        }
        return false;
    }
}
