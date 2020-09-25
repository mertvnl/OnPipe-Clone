using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 10f;
    public GameObject controller;
    public GameObject controller2;
    public bool canMove;

    private void Start()
    {
        canMove = false;
    }

    void FixedUpdate()
    {
        PipeMovement();
    }

    public void Move()
    {
        controller2.GetComponent<ButtonControls>().tapButton.SetActive(false);
        canMove = true;
    }

    public void PipeMovement()
    {
        if (controller.GetComponent<ColliderChecker>().canRotate && !controller.GetComponent<ColliderChecker>().stopAllMovement)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (!controller.GetComponent<ColliderChecker>().canRotate && !controller.GetComponent<ColliderChecker>().stopAllMovement)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (canMove)
        {
            if (!controller.GetComponent<ColliderChecker>().stopMoving && controller.GetComponent<ColliderChecker>().stopAllMovement)
            {
                transform.Translate(0, 0, 0);
                transform.Rotate(0, 0, 0);
            }
            if (controller.GetComponent<ColliderChecker>().stopMoving)
            {
                transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
            }
        }
    }
    
}
