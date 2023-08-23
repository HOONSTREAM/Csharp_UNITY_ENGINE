using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region �������
    public static ScoreManager Instance = null; // �̱��� ��ü
    public Text currentText;
    public Text BestText;
    private int current_score;
    private int Best_score;
    #endregion
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; //�̱��� ��ü�� ���� ������ ������ �ڱ� �ڽ��� �Ҵ��Ѵ�.
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
        //�ְ������� �ҷ��� Best_Score ������ �Ҵ��ϰ� ȭ�鿡 ǥ���Ѵ�.

        Best_score = PlayerPrefs.GetInt("Bestscore", 0);

        BestText.text = $"Best Score : {Best_score} �� ";
    }



    public int Score 
    { get { return current_score; } 
      set 
        {
            current_score = value;
            currentText.text = $"Score : {current_score} ��";

            if (current_score > Best_score) //�ְ����� ���� 
            {
                Best_score = current_score;

                BestText.text = $"Best Score : {Best_score} �� ";

                //��ǥ : �ְ����� Ŭ���̾�Ʈ ���ο� ����

                PlayerPrefs.SetInt("Bestscore", Best_score);
            }

        } 
    
    
    
    
    
    }
}
