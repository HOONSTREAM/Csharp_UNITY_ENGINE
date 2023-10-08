using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> TalkData;
    void Awake()
    {
        TalkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void Update()
    {
        
    }

    void GenerateData()
    {
        TalkData.Add(1000, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���?" ,"NPC ó�� Ŭ���غ���?"}); //��ȭ �ϳ����� ���������� ��������Ƿ� �迭�� ���
        TalkData.Add(100, new string[] { "������Ż�� ��������, ��� �̵��ϴ����� �����غ��� �� �� ����." }); //��ȭ �ϳ����� ���������� ��������Ƿ� �迭�� ���
        TalkData.Add(1001, new string[] { "���� 1001�� NPC, �׽�Ʈ������", "�׽�Ʈ�� �������̾����� ���ڴ�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == TalkData[id].Length)
        {
            
            return null;
        }
            
        else
        {
            
            return TalkData[id][talkIndex];
        }
        

    }
}