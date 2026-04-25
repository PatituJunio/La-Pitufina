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

            GameManager.instance.sumarEnergia(1); // Llama al controlador
            Destroy(gameObject);

        }
    }
}
