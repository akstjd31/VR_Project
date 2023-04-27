using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Funiture : MonoBehaviour
{

    public Material origin_mat;

    // ���� ������ ���͸����� �����ϸ� �����ϰ� ����.
    void Start()
    {
        origin_mat = this.gameObject.GetComponent<Renderer>().material;
    }

    // �÷��̾ �������� �� �� ���±��� �ٶ󺸸� ���� ����.
    public abstract Color ChangetheColor();

    public abstract void SetText(Text text);

    // �÷��̾��� ������ ����Ǿ����� ���� ������ ���͸����� �����´�.
    public Material SetOriginMaterial()
    {
        return origin_mat;
    }

    // �÷��̾�� ��ȣ�ۿ�
    public abstract void Interaction(GameObject obj);
}
