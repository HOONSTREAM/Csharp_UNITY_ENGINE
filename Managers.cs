 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // ��ü ���ϼ� ���� (����ƽ �ν��Ͻ�) - ����ƽ ��ü ����
    public static Managers Instance { get { Init();  return s_instance; } } // ������ �Ŵ����� �����´�. (������Ƽ ���)

    // Start is called before the first frame update
    void Start()
    {
        Init(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void Init() //�ν��Ͻ��� null�϶� �߻��ϴ� crash ����
    {
        if (s_instance == null) // instance�� Managers ������Ʈ�� �ܾ���� ������ null �̶��
        {
            GameObject go = GameObject.Find("@Managers"); // Gameobject @Managers �� ã�ƺ��� ���࿡ null �̶��

            if (go == null) // ���̶�ŰUI���� CreateGameobject,�� ������Ʈ�� ���̴� �۾��� �ڵ�� �Ѵ�.
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go); // �� ���ӿ�����Ʈ�� ������� ������ �� ����.
            Managers mg = go.GetComponent<Managers>();
        }
    }
}

