using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneChecker : MonoBehaviour
{
    //DeadZone Checker
    public GameObject deathPanel;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoseLevel());
        }
    }

    IEnumerator LoseLevel()
    {
        Lose();
        yield return new WaitForSeconds(2);
        
    }
    public void Lose()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
