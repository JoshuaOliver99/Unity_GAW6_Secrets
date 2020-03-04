using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one instance of EquipmentManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged; // Triggers when the equipment changes

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance; // Assign inventory to the inventory instance

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; // numSlots = EquipmentSlot.Length
        currentEquipment = new Equipment[numSlots]; // currentEquipment[] of size numSlots
    }


    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentLocation; // Translates equipmentSlot into int

        Equipment oldItem = null; // holds the old item

        if (currentEquipment[slotIndex] != null)// Check is EquipmentSlot is occupied
        {
            oldItem = currentEquipment[slotIndex]; // Make oldItem the currently equiped
            inventory.Add(oldItem); // Add oldItem back into inventory
        }

        if (onEquipmentChanged != null) // Methods to notify
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem; // Equip the newItem
    }



    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)// Check is EquipmentSlot is occupied
        {
            Equipment oldItem = currentEquipment[slotIndex]; // Make oldItem the currently equiped
            inventory.Add(oldItem); // Add oldItem back into inventory

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null) // Methods to notify
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    void updateEquipedDisplay()
    {

    }


}
