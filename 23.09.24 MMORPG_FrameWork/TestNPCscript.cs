using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPCscript : MonoBehaviour
{
    private int _mask = (1 << (int)Define.Layer.NPC);
    Texture2D _attackIcon;
    GameObject _player;
        
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("UnityChan");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, _mask))
            {
                if (hit.collider.gameObject.layer == (int)Define.Layer.NPC)
                {
                    
                    PlayerController pc = _player.GetComponent<PlayerController>();
                    pc.State = Define.State.Idle;
                    Debug.Log("NPC를 클릭합니다.!");
                    Managers.UI.ShowSceneUI<UI_Inven>();


                }

            }
        }

        if (GameObject.Find("UI_Inven"))
        {
            if (Input.anyKeyDown == true)
            {
                GameObject go = GameObject.Find("UI_Inven");
                Debug.Log("인벤토리를 닫습니다.");
                GameObject.Destroy(go);

            }
        }
       

    }
}

