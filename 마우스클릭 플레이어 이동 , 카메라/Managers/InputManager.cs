using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MonoBehaviour 상속을 받지않음으로써 컴포넌트가 아닌 일반 C# script로 사용한다.
//Input을 관리하는 매니저
public class InputManager
{

    public Action KeyAction = null; //델리게이트 (옵저버패턴 -> 입력이되는지 감시 후 입력되면 이벤트발생)
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
