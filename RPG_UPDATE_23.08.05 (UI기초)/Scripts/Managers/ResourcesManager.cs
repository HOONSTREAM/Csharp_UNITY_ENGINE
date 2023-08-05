using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<프리펩 생성 목적의 리소스매니저>

/*================================================================================*/

//툴로 직접 연결할 수 있지만 게임 프로젝트가 커지면 일일이 연결하기 힘드므로,
//코드상으로 프리펩을 생성할 수 있도록 한다.

/*================================================================================*/


public class ResourcesManager
{
    public T Load<T>(string path) where T : Object //유니티에서 참조할수 있는 모든 개체의 기본 클래스
    {
        return Resources.Load<T>(path); //Gameobject를 리턴해주는 함수다. (Gameobject변수 선언해서 리턴받으면 됨.)path : 폴더경로 (함수랩핑) Resources 산하 게임오브젝트
    }

    //Instantiate()함수를 사용하면 게임을 실행하는 도중에 게임오브젝트를 생성할 수 있다.
    public GameObject Instantiate(string path, Transform parent = null) //Instantiate 함수(Gameobject 실체생성을 리턴하는함수) 랩핑
    {
        GameObject prefab = Load<GameObject>($"PreFabs/{path}"); //Resources.Load 함수를 랩핑한 함수를 가져온다.
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent); //Object.을 안붙이면 리소스매니저 클래스 안의 랩핑함수 Instatiate를 재귀호출 해버리기 때문.
    }

    public void Destroy(GameObject go)
    {

        if (go == null)
            return;

        Object.Destroy(go);

    }
}
