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
        //�ְ������� �ҷ��� Best_Score ������ �Ҵ��ϰ� ȭ�鿡 ǥ���Ѵ�.

        Best_score = PlayerPrefs.GetInt("Bestscore", 0);

        BestText.text = $"Best Score : {Best_score} �� ";
    }

    //current_score ������ ���� �ְ� ȭ�鿡 ǥ��
    public void SetScore(int value)
    {
        current_score++;

        currentText.text = $"Score : {current_score} ��";

       

        if (current_score > Best_score)
        {
            Best_score = current_score;

            BestText.text = $"Best Score : {Best_score} �� ";

            //��ǥ : �ְ����� Ŭ���̾�Ʈ ���ο� ����

            PlayerPrefs.SetInt("Bestscore", Best_score);
        }
    }

    public int GetScore()
    {
        return current_score;
    }

}
