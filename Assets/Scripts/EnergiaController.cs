using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaController : MonoBehaviour
{
    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManagerController.instance.PlayBarritaSound();
            GameManagerController.instance.sumarEnergia(10);
            
            Destroy(gameObject);

        }
    }
}
