using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx 
{

    public BaseScene CurrentScene
    { get { return GameObject.FindObjectOfType<BaseScene>(); } } //BaseScene ������Ʈ�� ����ִ� object�� ã��. }

  public void LoadScene(Define.Scene type)
    {
        CurrentScene.Clear(); //���� ���� Ŭ�����ϰ� ���� ��(��)���� �Ѿ�� �ϱ�����.
        SceneManager.LoadScene(GetSceneName(type));


    }

    string GetSceneName(Define.Scene type)
    {
       string name = System.Enum.GetName(typeof(Define.Scene), type);


        return name;
    }




}
