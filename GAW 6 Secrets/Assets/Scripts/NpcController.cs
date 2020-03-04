using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float moveSpeed;
    public float viewDistance;

    public List<string> friendlyFactions = new List<string>(); // Friendly factions


    private void Start()
    {

    }
    private void Update()
    {

    }



    // will wonder around spawn location

    // is friendly towards list<string>
    // more items of clothing == less likely to detect

    // will chase the player when noticed 
    // and stop if out of range

}

