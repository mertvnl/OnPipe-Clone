using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControl : MonoBehaviour
{
    Rigidbody rb;
    //public AudioClip hit;             // Sound fx if needed
    //public AudioSource audioSource;   // Sound fx if needed
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll; // Freeze the cubes
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scorer"))
        {
            rb.constraints = RigidbodyConstraints.None; // After collision unfreeze the cubes
            rb.velocity = Vector3.down * Time.deltaTime * 500f; // After collision move the cubes towards bottom so it looks cool
            //audioSource.Play(); //Sound effect if needed.
            Destroy(gameObject, 1.2f); // After collision delete the cubes due to performance purposes
        }
    }


}
