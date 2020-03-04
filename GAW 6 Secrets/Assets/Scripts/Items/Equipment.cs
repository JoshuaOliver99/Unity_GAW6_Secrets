using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentLocation equipmentLocation; // Which EquipmentSlot the item occupies
    public Factions[] factions; // Which Faction the item belongs too
    public Gender[] gender; // Which Gender the item is for

    public override void Use()
    {
        base.Use(); // Inherit Use() from Item.cs
        EquipmentManager.instance.Equip(this); // Equip the item

        // Remove from inventory
        RemoveFromInventory();
    }
}

public enum EquipmentLocation { Head, Torso, Legs, Feet, Special1, Special2 }
public enum Factions { Cowboy, Chef }
public enum Gender { Unisex, Male, Female }

