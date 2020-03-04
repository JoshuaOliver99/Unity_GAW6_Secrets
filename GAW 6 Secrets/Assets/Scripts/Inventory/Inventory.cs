using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback; // Triggers when the inventory changes

    public int invSpace = 20; // Inventory space
    public List<Item> items = new List<Item>(); // Inventory items of size invSpace

    public bool Add (Item item)
    {
        if (items.Count >= invSpace) // Inventory out of space
        {
            Debug.Log("Not enough room.");
            return false;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item); // Nulls the item

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
