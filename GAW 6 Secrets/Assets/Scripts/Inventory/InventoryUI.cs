﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform equipmentParent;

    Inventory inventory; // Referance to the Inventory
    EquipmentManager equipmentManager; // Referance to the EquipmentManager

    InventorySlot[] slots; // Reference to all inventory slots


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        
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
