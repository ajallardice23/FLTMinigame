using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    //Script to load levels (attached to main menu)
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Level4()
    {
        SceneManager.LoadScene(4);
    }
}
