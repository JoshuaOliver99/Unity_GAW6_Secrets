using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentLocation equipmentLocation; // EquipmentSlot the item occupies
    public Faction faction; // Faction the item belongs to
    public Gender gender; // Gender the item belongs to

    public override void Use()
    {
        base.Use(); // Inherit Use() from Item.cs
        EquipmentManager.instance.Equip(this); // Equip the item
        RemoveFromInventory();
    }
}

public enum EquipmentLocation { Head, Torso, Legs, Feet, Special1, Special2 }
public enum Faction { none, Cowboy, Chef }
public enum Gender { Unisex, Male, Female }

