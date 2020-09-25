using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    // Destroy the GameObject that no longer in the game screen to improve performance
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
