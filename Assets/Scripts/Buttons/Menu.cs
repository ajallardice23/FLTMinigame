using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject LevelUI;
    public GameObject Tutorial;
    
    public void OpenLevelUI()
    {
        LevelUI.SetActive(true);
    }
    
    public void CloseLevelUI()
    {
        LevelUI.SetActive(false);
    }
    
    public void Options()
    {
        
    }
    
    
    public void OpenTutorial()
    {
        Tutorial.SetActive(true);
    }
    
    public void CloseTutorial()
    {
        Tutorial.SetActive(false);
    }

}
