using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject PauseUI;
    //Restarting scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Unpause/play
    public void PlayScene()
    {
        PauseUI.SetActive(false);
    }
    //Pause game
    public void PauseUIActive()
    {
        PauseUI.SetActive(true);
    }
    //Back to main menu
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
