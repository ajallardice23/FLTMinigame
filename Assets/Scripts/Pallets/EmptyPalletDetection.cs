using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPalletDetection : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public LevelController levelController;

    //If pallets enter, access level controller script and add a emptypallet to count
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EmptyPalletTrigger")
        {
            particleSystem.Stop();
            levelController.EmptyPalletEntered();
        }
    }
    //If pallets exits, access level controller script and remove a emptypallet from count
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EmptyPalletTrigger")
        {
            particleSystem.Play();
            levelController.EmptyPalletExited();
        }
    }
}
