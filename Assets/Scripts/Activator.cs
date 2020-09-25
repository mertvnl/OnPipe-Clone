using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    //Spawn the cubes when they are about to show on screen to improve performance
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spawner"))
        {
            collision.gameObject.GetComponent<CubeActivator>().cubes.SetActive(true);
        }
          
    }
}
