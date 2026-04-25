using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocasPInchan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            //Quitan salud al chocar con la roca
            Console.WriteLine("Me quita salud");
        } 
            
            
    }
}
