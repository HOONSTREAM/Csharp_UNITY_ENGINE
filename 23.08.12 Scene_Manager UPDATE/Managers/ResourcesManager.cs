using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<������ ���� ������ ���ҽ��Ŵ���>

/*================================================================================*/

//���� ���� ������ �� ������ ���� ������Ʈ�� Ŀ���� ������ �����ϱ� ����Ƿ�,
//�ڵ������ �������� ������ �� �ֵ��� �Ѵ�.

/*================================================================================*/


public class ResourcesManager
{
    public T Load<T>(string path) where T : Object //����Ƽ���� �����Ҽ� �ִ� ��� ��ü�� �⺻ Ŭ����
    {
        return Resources.Load<T>(path); //(������ ������Ʈ ����(��üȭ�ƴ�))�Լ��� �����Ѵ�. path : ������� (�Լ�����)
    }

    //Instantiate()�Լ��� ����ϸ� ������ �����ϴ� ���߿� ���ӿ�����Ʈ�� ������ �� �ִ�.
    public GameObject Instantiate(string path, Transform parent = null) //Instantiate �Լ�(Gameobject ��ü������ �����ϴ��Լ�) ����
    {
        GameObject prefab = Load<GameObject>($"PreFabs/{path}"); //Resources.Load �Լ��� ������ �Լ��� �����´�.
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if(index>0)
            go.name = go.name.Substring(0, index); //index ���ڿ��� �ڸ���.

        return go; //Object.�� �Ⱥ��̸� ���ҽ��Ŵ��� Ŭ���� ���� �����Լ� Instatiate�� ���ȣ�� �ع����� ����.
    }

    public void Destroy(GameObject go)
    {

        if (go == null)
            return;

        Object.Destroy(go);

    }
}
