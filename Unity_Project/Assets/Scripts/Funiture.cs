using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Funiture : MonoBehaviour
{
    // ���� ������ ���͸����� �����ϸ� �����ϰ� ����.
    void Start()
    {
    }

    // �÷��̾ �������� �� �� ���±��� �ٶ󺸸� ���� ����.
    public abstract Color ChangetheColor();

    public abstract void SetText(Text text);

    // �÷��̾�� ��ȣ�ۿ� 
    public abstract void Interaction(GameObject obj);
}
