using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public GameObject player;
    public Collider col;
    public Text scoreText;
    public Text scoreTextPanel;
    public Text scoreTextFinishPanel;
    public int score;

    private void Start()
    {
        SetVariables();
    }

    private void Update()
    {
       //Check whether the player colliding with pipe or not
        if (player.GetComponent<PlayerController>().canScore)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
    }

    //If player colliding with cubes add score
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            AddScore();
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreTextPanel.text = score.ToString();
        scoreTextFinishPanel.text = score.ToString();
    }

    void SetVariables()
    {
        score = 0;
        scoreText.text = score.ToString();
        scoreTextPanel.text = score.ToString();
        scoreTextFinishPanel.text = score.ToString();
    }
}
