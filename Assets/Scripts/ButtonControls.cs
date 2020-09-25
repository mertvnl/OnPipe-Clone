using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour
{
    public GameObject tapButton;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
    }
    public void NextLevel()
    {
        return;
    }
    public void StartGame()
    {
        tapButton.SetActive(false);
    }
}
