using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Funiture : MonoBehaviour
{

    public Material origin_mat;

    // 기존 가구의 머터리얼이 존재하면 저장하고 있음.
    void Start()
    {
        origin_mat = this.gameObject.GetComponent<Renderer>().material;
    }

    // 플레이어가 게이지가 다 찬 상태까지 바라보면 색상 변경.
    public abstract Color ChangetheColor();

    public abstract void SetText(Text text);

    // 플레이어의 시점이 변경되었으면 기존 가구의 머터리얼을 가져온다.
    public Material SetOriginMaterial()
    {
        return origin_mat;
    }

    // 플레이어와 상호작용
    public abstract void Interaction(GameObject obj);
}
