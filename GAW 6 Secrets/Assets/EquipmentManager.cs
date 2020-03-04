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
    public GameObject player;
    Equipment[] currentEquipment;// Currently equiped items

    // Callback for unequipping / equipping
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged; // Triggers when the equipment changes

    Inventory inventory; // Referance to the inventory

    private void Start()
    {
        inventory = Inventory.instance; // Get a referance to the inventory

        int numSlots = System.Enum.GetNames(typeof(EquipmentLocation)).Length; // numSlots = EquipmentLocation.Length
        currentEquipment = new Equipment[numSlots]; // currentEquipment[] of size numSlots
    }


    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentLocation; // Translates equipmentSlot into an index int (e.g. head = 0)
        Equipment oldItem = null; // Var to hold the old item

        // if (EquipmentSlot is occupied) add the old item to the inventory
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
        // if (EquipmentSlot is occupied)
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



    /*
    public void displayEquipment(GameObject gameObject)
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            // spawn sprites as child of player
        }

    }
      
    public List<string> currentFactions()
    {
        List<string> factions = new List<string>();

        for (int i = 0; i < currentEquipment.Length; i++)
        {
            factions + currentEquipment.
        }
        return a;
    }
    */
}
