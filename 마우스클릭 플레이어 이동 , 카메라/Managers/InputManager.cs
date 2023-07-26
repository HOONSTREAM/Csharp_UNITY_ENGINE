using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MonoBehaviour ����� �����������ν� ������Ʈ�� �ƴ� �Ϲ� C# script�� ����Ѵ�.
//Input�� �����ϴ� �Ŵ���
public class InputManager
{

    public Action KeyAction = null; //��������Ʈ (���������� -> �Է��̵Ǵ��� ���� �� �ԷµǸ� �̺�Ʈ�߻�)
    public Action<Define.MouseEvent> MouseAction = null;
    bool _pressed = false;
   public void OnUpdate()
    {
     
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;

            }

            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }


    }

}
