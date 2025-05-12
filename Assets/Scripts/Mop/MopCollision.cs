using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopCollision : MonoBehaviour
{
    //If player collides with mop - death
    public GameObject deathScreen;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pallet" || collision.gameObject.tag == "EmptyPallet")
        {
            deathScreen.gameObject.SetActive(true);
        }
    }
}
