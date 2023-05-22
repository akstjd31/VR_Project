using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Table : Funiture
{
    private bool unlock = false; // 해당 서랍이 열쇠로 인해 열렸는지 확인
    void start()
    {
        
    }

    public override Color ChangetheColor()
    {
        return new Color(128f / 255f, 0, 128f / 255f);
    }

    public override bool Interaction(GameObject obj, bool flag)
    {
            if (!flag)
            {
                switch (obj.name) 
                {
                    case "Computer_Table_L":
                        // 플레이어가 열쇠를 지닌 상태에서 해당 오브젝트가 잠겨있을 때
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
                            return false; // 언락 상태가 아니면 계속 false 반환
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
