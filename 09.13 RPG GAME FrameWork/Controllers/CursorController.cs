using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster);
    Texture2D _attackIcon;
    Texture2D _handIcon;

    void Start()
    {
        _attackIcon = Managers.Resources.Load<Texture2D>("Textures/Cursor/cursor(12)");
        _handIcon = Managers.Resources.Load<Texture2D>("Textures/Cursor/cursor(1)");

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100.0f, _mask))
        {

            if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {

                Cursor.SetCursor(_attackIcon, new Vector2(_attackIcon.width / 5, 0), CursorMode.Auto);
            }

            else
            {

                Cursor.SetCursor(_handIcon, new Vector2(_handIcon.width / 3, 0), CursorMode.Auto);
            }
        }
    }
}
