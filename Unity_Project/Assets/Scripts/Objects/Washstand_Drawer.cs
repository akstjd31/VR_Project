using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Washstand_Drawer : Funiture
{
    private bool unlock = false;

    void start()
    {
    }
    public override Color ChangetheColor()
    {
        return new Color(255f/255f, 165f/255f, 0); // orange
    }
    
    public override bool Interaction(GameObject obj, bool flag)
    {
        
        if (!flag)
        {
            switch (obj.name) 
            {
                case "Washstand_Drawer_03":
                    if (!unlock && PlayerManager.Instance.count > 0)
                    {
                        PlayerManager.Instance.count--;
                        unlock = true;
                    }

                    if (unlock)
                        obj.transform.parent.GetComponent<Animator>().Play("openpull_01");
                    else
                    {
                        PlayerManager.Instance.lockText.SetActive(true);
                        StartCoroutine(PlayerManager.Instance.FadeTextToZero(PlayerManager.Instance.lockText.GetComponent<Text>()));
                        return false;
                    }
                    break;
                default:
                    obj.transform.parent.GetComponent<Animator>().Play("openpull_01");
                    break;
            }
    
            return true;
        }
        else
        {
            obj.transform.parent.GetComponent<Animator>().Play("closepush_01");
            return false;
        }
    }
}
