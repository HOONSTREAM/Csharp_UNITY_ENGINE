using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region 멤버변수
    public static ScoreManager Instance = null; // 싱글톤 객체
    public Text currentText;
    public Text BestText;
    private int current_score;
    private int Best_score;
    #endregion
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; //싱글톤 객체에 값이 없으면 생성된 자기 자신을 할당한다.
        }

        GameObject go = GameObject.Find("EventSystem");
        if (go == null)
        {
            go = new GameObject() { name = "@EventSystem" };
            go.AddComponent<EventSystem>();
            Object.DontDestroyOnLoad(go);
        }

    }

    private void Start()
    {
        //최고점수를 불러와 Best_Score 변수에 할당하고 화면에 표시한다.

        Best_score = PlayerPrefs.GetInt("Bestscore", 0);

        BestText.text = $"Best Score : {Best_score} 점 ";
    }



    public int Score 
    { get { return current_score; } 
      set 
        {
            current_score = value;
            currentText.text = $"Score : {current_score} 점";

            if (current_score > Best_score) //최고점수 갱신 
            {
                Best_score = current_score;

                BestText.text = $"Best Score : {Best_score} 점 ";

                //목표 : 최고점수 클라이언트 내부에 저장

                PlayerPrefs.SetInt("Bestscore", Best_score);
            }

        } 
    
    
    
    
    
    }
}
