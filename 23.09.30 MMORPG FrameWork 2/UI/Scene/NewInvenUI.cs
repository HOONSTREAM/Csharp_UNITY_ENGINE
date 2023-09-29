using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewInvenUI : UI_Scene
{
    
    [SerializeField]
    GameObject inventoryPanel;
    PlayerInventory inven; //플레이어 인벤토리 참조
    PlayerStat stat; //플레이어 스텟 참조 (골드업데이트)
    

    public Slot[] slots;
    public Transform slotHolder;

    bool activeInventory = false;

    private void Start()
    {
        stat= GetComponent<PlayerStat>(); //골드 업데이트를 위한 플레이어 스텟 참조
        inven = PlayerInventory.Instance;
       
        slots=slotHolder.GetComponentsInChildren<Slot>();
        inventoryPanel.SetActive(activeInventory);
        
        inven.onChangeItem += RedrawSlotUI;

        BindEvent(inventoryPanel, (PointerEventData data) => { inventoryPanel.transform.position = data.position; }, Define.UIEvent.Drag);

    }

   


    private void Update()
    {
        #region Gold UPDATE
        //TODO
        //GameObject goldPanel = GameObject.Find("GoldText").gameObject;
        //TextMeshProUGUI goldPanelText = goldPanel.GetComponent<TextMeshProUGUI>();
        //goldPanelText.text = stat.Gold.ToString();
        #endregion


        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
            Managers.Sound.Play("Inven_Open");

        }
    }

    void RedrawSlotUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;
        }

        for(int i = 0; i< slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for(int i = 0; i<inven.player_items.Count; i++)
        {
            slots[i].item = inven.player_items[i];
            slots[i].UpdateSlotUI();
        }
    }

}


