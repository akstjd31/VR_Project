using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Funiture : MonoBehaviour
{
    public float delayTime = 5.0f;
    public string GetName()
    {
        return this.name;
    }

    public abstract Color ChangetheColor();

    // 플레이어와 가구의 상호작용
    public abstract void Interaction();
}
