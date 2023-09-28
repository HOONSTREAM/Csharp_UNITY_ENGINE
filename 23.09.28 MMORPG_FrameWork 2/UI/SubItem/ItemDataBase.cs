using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 전체 아이템을 저장하고있을 데이터베이스 
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
          GameObject go =  Instantiate(fielditemPrefab, pos[i], Quaternion.identity); //Quaternion.identity는 회전없음을 나타내는 쿼터니언
          go.GetComponent<FieldItem>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
