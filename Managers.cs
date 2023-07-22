 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 객체 유일성 보장 (스태틱 인스턴스) - 스태틱 객체 생성
    public static Managers Instance { get { Init();  return s_instance; } } // 유일한 매니저를 가져온다. (프로퍼티 사용)

    // Start is called before the first frame update
    void Start()
    {
        Init(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void Init() //인스턴스가 null일때 발생하는 crash 방지
    {
        if (s_instance == null) // instance의 Managers 컴포넌트를 긁어오고 싶을때 null 이라면
        {
            GameObject go = GameObject.Find("@Managers"); // Gameobject @Managers 를 찾아보고 만약에 null 이라면

            if (go == null) // 하이라키UI에서 CreateGameobject,후 컴포넌트를 붙이는 작업을 코드로 한다.
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go); // 이 게임오브젝트는 마음대로 삭제할 수 없다.
           s_instance = go.GetComponent<Managers>(); //s_instance 스태틱객체에 Managers 컴포넌트 할당한다.
        }
    }
}

