using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MonoBehaviour ����� �����������ν� ������Ʈ�� �ƴ� �Ϲ� C# script�� ����Ѵ�.
//Input�� �����ϴ� �Ŵ���
public class InputManager
{

    public Action KeyAction = null; //��������Ʈ (���������� -> �Է��̵Ǵ��� ���� �� �ԷµǸ� �̺�Ʈ�߻�)
    
   public void OnUpdate()
    {
        if (Input.anyKey == false)
        {
            return;
        }

        if (KeyAction != null)
        {
            KeyAction.Invoke();
        }

    }

}
