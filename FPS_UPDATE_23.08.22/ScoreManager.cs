using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text currentText;
    public Text BestText;

    GameObject go = GameObject.Find("Plane1");

    private int current_score;
    private int Best_score;

    private void Start()
    {
        //최고점수를 불러와 Best_Score 변수에 할당하고 화면에 표시한다.

        Best_score = PlayerPrefs.GetInt("Bestscore", 0);

        BestText.text = $"Best Score : {Best_score} 점 ";
    }

    //current_score 변수에 값을 넣고 화면에 표시
    public void SetScore(int value)
    {
        current_score++;

        currentText.text = $"Score : {current_score} 점";

       

        if (current_score > Best_score)
        {
            Best_score = current_score;

            BestText.text = $"Best Score : {Best_score} 점 ";

            //목표 : 최고점수 클라이언트 내부에 저장

            PlayerPrefs.SetInt("Bestscore", Best_score);
        }
    }

    public int GetScore()
    {
        return current_score;
    }

}
