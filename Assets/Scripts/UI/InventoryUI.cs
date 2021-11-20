using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory_game_manager inventory;
    public Transform inventoryPanel;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory_game_manager.instance;
        inventory.onItemsChangedCallback += UpdateUI;


    }

    // Update is called once per frame
    void Update()
    {
       
        slots = inventoryPanel.GetComponentsInChildren<InventorySlot>();
        
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
