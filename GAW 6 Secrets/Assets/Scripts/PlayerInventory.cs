using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        invetoryManager();
    }


    private void invetoryManager()
    {
        if (Input.GetKeyDown("q"))
        {
            if (inventoryPanel.activeSelf == true)
                inventoryPanel.SetActive(false);
            else
                inventoryPanel.SetActive(true);
        }

    }
}
