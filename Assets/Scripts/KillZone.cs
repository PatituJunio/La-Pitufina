using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // si algun objeto toca el cuadrado rojo debe destruirse
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))//si cae la pitu pierde vida
        {
            GameManager.instance.PerderVida(true); // Llama al controlador
        }
        else {
            Destroy(collision.gameObject);
        }

        
    }
}
