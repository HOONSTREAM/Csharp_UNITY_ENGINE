 using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour

{
    
    static Managers s_instance; // ��ü ���ϼ� ���� (����ƽ �ν��Ͻ�) - ����ƽ ��ü ����
    static Managers Instance { get { Init(); return s_instance; } } // ������ �Ŵ����� �����´�. (������Ƽ ���)

    InputManager _input = new InputManager();

    public static InputManager Input { get { return Instance._input; } }
   
   
    void Start()
    {
        Init(); 
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init() //�ν��Ͻ��� null�϶� �߻��ϴ� crash ����
    {
        if (s_instance == null) // instance�� Managers ������Ʈ�� �ܾ���� ������ null �̶��
        {
            GameObject go = GameObject.Find("@Managers"); // Gameobject @Managers �� ã�ƺ��� ���࿡ null �̶��

            if (go == null) // ���̶�ŰUI���� CreateGameobject,�� ������Ʈ�� ���̴� �۾��� �ڵ�� �Ѵ�.
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>(); //@Managers ���� ������Ʈ�� Managers ������Ʈ�� ���δ�.
            }
            DontDestroyOnLoad(go); // �� ���ӿ�����Ʈ�� ������� ������ �� ����.
            s_instance = go.GetComponent<Managers>(); //���� s_instance�� Managers�� ������Ʈ�� �Ҵ��Ѵ�.
        }
    }
}

