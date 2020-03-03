using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;

    public bool head;
    public bool torso;
    public bool legs;
    public bool feet;
    public bool special;

    public List<string> factions = new List<string>();
}
