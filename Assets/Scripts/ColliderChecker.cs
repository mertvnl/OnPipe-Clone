using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ColliderChecker : MonoBehaviour
{

    public GameObject pipe;
    public GameObject player;
    private bool playerCanMove;
    public bool stopMoving;
    public GameObject deathPanel;
    public GameObject winPanel;
    public bool canRotate;
    public bool stopAllMovement;
    public GameObject finishParticle;
    public GameObject hitParticle;
    public MeshRenderer playerMesh;
    public PlayerController playerMovement;
    public GameObject particleRight;
    public GameObject particleLeft;

    private void Start()
    {
        SetVariables();
    }

    private void FixedUpdate()
    {
        if (playerCanMove)
        {
            player.transform.Translate(0, 0, -10f * Time.deltaTime);
        }
    }

    //Colliders
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("DeadZone"))
        {
            StartCoroutine(Lose());
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(FinishLevel());
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            canRotate = false;
        }
        if (other.gameObject.CompareTag("Checkpoint2"))
        {
            canRotate = true;
        }

    }

    //Finish actions
    IEnumerator FinishLevel()
    {
        stopAllMovement = true;
        stopMoving = false;
        playerCanMove = true;
        PlayFinishParticle();
        yield return new WaitForSeconds(2);
        Finish();
    }

    public void Finish()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    //Lose actions
    IEnumerator Lose()
    {
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        particleRight.SetActive(false);
        particleLeft.SetActive(false);
        playerMovement.enabled = false;
        stopAllMovement = true;
        stopMoving = false;
        playerMesh.enabled = false;
        PlayHitParticle();
        yield return new WaitForSeconds(2f);
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void PlayFinishParticle()
    {
        Instantiate(finishParticle, finishParticle.transform.position, finishParticle.transform.rotation);
    }
    public void PlayHitParticle()
    {
        Instantiate(hitParticle, hitParticle.transform.position, hitParticle.transform.rotation);
    }

    //Setting the variables
    public void SetVariables()
    {
        playerMesh = player.GetComponent<MeshRenderer>();
        playerMovement = player.GetComponent<PlayerController>();
        canRotate = true;
        stopMoving = true;
        playerCanMove = false;
        stopAllMovement = false;
    }
}
