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
        TalkData.Add(1000, new string[] { "안녕?", "이 곳에 처음 왔구나?" ,"NPC 처음 클릭해보니?"}); //대화 하나에는 여러문장이 들어있으므로 배열을 사용
        TalkData.Add(100, new string[] { "워프포탈로 보이지만, 어떻게 이동하는지는 연구해봐야 할 것 같다." }); //대화 하나에는 여러문장이 들어있으므로 배열을 사용
        TalkData.Add(1001, new string[] { "나는 1001번 NPC, 테스트중이지", "테스트가 성공적이었으면 좋겠다." });
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
