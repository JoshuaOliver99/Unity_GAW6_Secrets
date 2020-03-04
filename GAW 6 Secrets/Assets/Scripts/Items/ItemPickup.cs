using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
            {
                Debug.Log("picked up: " + item);
                Destroy(gameObject);
            }
        }
    }



}
