using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnteojosController : MonoBehaviour
{
    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

           
            GameManagerController.instance.ActivarAnteojos(); // Llama al controlador
            Destroy(gameObject);

        }
    }
}
