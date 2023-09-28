using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ü �������� �����ϰ����� �����ͺ��̽� 
public class ItemDataBase : MonoBehaviour
{
   public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;

    }

    public List<Item> itemDB = new List<Item>();
    public GameObject fielditemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        for(int i = 0; i<5; i++)
        {
          GameObject go =  Instantiate(fielditemPrefab, pos[i], Quaternion.identity); //Quaternion.identity�� ȸ�������� ��Ÿ���� ���ʹϾ�
          go.GetComponent<FieldItem>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
