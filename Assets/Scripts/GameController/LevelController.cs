using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public TextMeshProUGUI palletsLeft;
    public TextMeshProUGUI emptyPalletsLeft;
    public GameObject winScreen;
    public GameObject PalletUI;
    public int palletCount;
    private int palletsInZones;
    public int emptyPalletCount;
    private int emptyPalletsInZones;

    void Start()
    {
        palletsInZones = 0;
    }

    void Update()
    {
        palletsLeft.text = (palletCount - palletsInZones).ToString();
        emptyPalletsLeft.text = (emptyPalletCount - emptyPalletsInZones).ToString();
    }

    //Registers when pallet placed in zone
    public void PalletEntered()
    {
        palletsInZones++;

        //Round win condition (if pallets and empty pallets all in correct place wingame)
        if (palletsInZones >= palletCount && emptyPalletsInZones >= emptyPalletCount)
        {
            WinGame();
        }
        Debug.Log("pallet entered" + palletsInZones);
    }

    //Registers when pallet removed from zone
    public void PalletExited()
    {
        palletsInZones--;

        if (palletsInZones < 0)
        {
            palletsInZones = 0;
        }
        Debug.Log("pallet exited" + palletsInZones);
    }
    
    //Registers emptypallet enetered
    public void EmptyPalletEntered()
    {
        emptyPalletsInZones++;

        if (emptyPalletsInZones >= emptyPalletCount && palletsInZones >= palletCount)
        {
            WinGame();
        }
        Debug.Log("pallet entered" + palletsInZones);
    }

    //Registers emptypallet removed
    public void EmptyPalletExited()
    {
        emptyPalletsInZones--;

        if (emptyPalletsInZones < 0)
        {
            palletsInZones = 0;
        }
        Debug.Log("pallet exited" + palletsInZones);
    }

    //Setting winscreen
    private void WinGame()
    {
        winScreen.SetActive(true);
        PalletUI.SetActive(false);
    }
}
