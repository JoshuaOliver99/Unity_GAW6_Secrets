using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    int speed = 5;
    void Update()
    {
        keyboardInput();
    }

    private void keyboardInput()
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
}
