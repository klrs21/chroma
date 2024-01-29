using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Debug.Log("Picked up");
    }
}
