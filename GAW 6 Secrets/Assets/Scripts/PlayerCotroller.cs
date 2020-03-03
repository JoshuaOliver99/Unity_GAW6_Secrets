using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    // INVENTORY
    [SerializeField] GameObject inventoryPanel = null;

    // MOVEMENT
    int speed = 5;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (!inventoryIsOpen())
            movementManager(); // Allow movement

        invetoryManager(); // Allow opening inventory
    }




    private void movementManager()
    {
        // Move left or right
        if (Input.GetKey("a") && !Input.GetKey("d"))
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        else if (Input.GetKey("d") && !Input.GetKey("a"))
            transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);

        // Move up or down
        if (Input.GetKey("w") && !Input.GetKey("s"))
            transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        else if (Input.GetKey("s") && !Input.GetKey("w"))
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
    }

    private void invetoryManager()
    {
        // Open inventory
        if (Input.GetKeyDown("q"))
        {
            if (inventoryIsOpen())
                inventoryPanel.SetActive(false);
            else
                inventoryPanel.SetActive(true);
        }
    }

    private bool inventoryIsOpen()
    {
        if (inventoryPanel.activeSelf == true)
            return true;
        else
            return false;
    }


}
