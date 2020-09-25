using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 maxScale;
    Vector3 targetScale;
    Vector3 minusTargetScale;
    Vector3 collidedScale;
    private bool mouseDown;
    private bool collided;
    public bool canScore;
    public GameObject buttonControl;
    public GameObject particleRight;
    public GameObject particleLeft;
    void Start()
    {
        SetVariables();
    }

    void Update()
    {
        //Check if player can move
        if (Input.GetMouseButton(0) && buttonControl.GetComponent<PipeController>().canMove)
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        if (collided)
        {
            PlayParticles();
        }
        else
        {
            StopParticles();
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    //Collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            collided = true;
            collidedScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, transform.localScale.z + 0.05f);
        }
    }

    public void PlayerMovement()
    {
        if (mouseDown)
        {
            transform.localScale += targetScale;
            if (collided)
            {
                transform.localScale = collidedScale;
                canScore = true;
            }
        }
        if (!mouseDown)
        {
            canScore = false;
            collided = false;
            transform.localScale += minusTargetScale;
            if (transform.localScale.x > maxScale.x)
            {
                transform.localScale = maxScale;
            }
        }
    }

    public void PlayParticles()
    {
        particleRight.SetActive(true);
        particleLeft.SetActive(true);
    }

    public void StopParticles()
    {
        particleRight.SetActive(false);
        particleLeft.SetActive(false);
    }

    public void SetVariables()
    {
        Time.timeScale = 1;
        canScore = false;
        collided = false;
        mouseDown = false;
        maxScale = new Vector3(2f, 2f, 2f);
        targetScale = new Vector3(-0.2f, -0.2f, -0.2f);
        minusTargetScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
}
