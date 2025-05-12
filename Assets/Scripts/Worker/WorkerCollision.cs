using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkerCollision : MonoBehaviour
{
    //On player collision with worker - death 
    public GameObject DeathScreen;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pallet" || collision.gameObject.tag == "EmptyPallet")
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        DeathScreen.gameObject.SetActive(true);
    }
}
