using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // Referance to the icon
    public Button removeButton;

    Item item; // Referance to the current item in slot

    public void AddItem (Item newItem) // When a slot is occuipied
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot() // When a slot is cleared
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton() // On clicking RemoveButton 
    {
        Inventory.instance.Remove(item); 
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
