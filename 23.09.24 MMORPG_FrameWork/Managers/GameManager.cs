using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject _player;
    /*나중에 서버랑 연동되면 딕셔너리로 int ID로 관리*/
    //Dictionary<int,GameObject> _players = new Dictionary<int,GameObject>();
    
    HashSet<GameObject> _monsters = new HashSet<GameObject>(); //딕셔너리랑 유사하지만 key가 없음

    public Action<int> OnSpawnEvent; //액션에 인트전달 ->몬스터 개체 숫자를 의미
   
    public GameObject GetPlayer() { return _player; }

    public GameObject Spawn(Define.WorldObject type , string path, Transform parent = null)
    {

       GameObject go =  Managers.Resources.Instantiate(path,parent);

        switch (type)
        {
            case Define.WorldObject.Monster:
                _monsters.Add(go);
                if (OnSpawnEvent != null)
                    OnSpawnEvent.Invoke(1);
                break;
            case Define.WorldObject.Player:
                _player = go;
                break;

        }

        return go;

    }

    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        BaseController bc = go.GetComponent<BaseController>();

        if (bc == null)
            return Define.WorldObject.Unknown;

        return bc.WorldObjectType;

    }

    public void DeSpawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObject.Monster:
                {
                    if (_monsters.Contains(go))
                    {
                        _monsters.Remove(go);
                        if (OnSpawnEvent != null)
                        {
                            OnSpawnEvent.Invoke(-1); //1마리가 줄었다는 의미
                        }
                      
                    }
                      
                }
                
                break;
            case Define.WorldObject.Player:
                {

                    if (_player == go)
                        _player = null;
                }
                break;

        }

        Managers.Resources.Destroy(go);
    }

}
