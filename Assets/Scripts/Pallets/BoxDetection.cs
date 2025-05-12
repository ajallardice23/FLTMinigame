using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetection : MonoBehaviour
{


    public ParticleSystem particleSystem;
    public LevelController levelController;
    //If pallets enter, access level controller script and add a pallet to count
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PalletTrigger")
        {
            particleSystem.Stop();
            levelController.PalletEntered();
        }
    }
    //If pallets exits, access level controller script and remove a pallet from count
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PalletTrigger")
        {
            particleSystem.Play();
            levelController.PalletExited();
        }
    }
}
