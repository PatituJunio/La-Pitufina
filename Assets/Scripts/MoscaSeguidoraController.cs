using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaSeguidoraController : MonoBehaviour
{
    [SerializeField] private Transform jugador; // Arrastra a tu jugador aquí en el Inspector
    [SerializeField] private float velocidad = 3f; // Velocidad de movimiento del enemigo

    private Rigidbody2D rb;


   // [Header("Sonidos")]
  //  public AudioClip comiendoSound;
  //  private AudioSource playerAudio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Verificamos que el jugador exista en la escena para evitar errores
        if (jugador != null)
        {
            // Calculamos la dirección hacia el jugador (Normalizada para mantener una velocidad constante)
            Vector2 direccion = (jugador.position - transform.position).normalized;

            // Movemos el enemigo usando el Rigidbody2D
            rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManagerController.instance.PlayMoscaSound();
            GameManagerController.instance.SumarPuntos(10);
            
            Destroy(gameObject);

        }
    }
}
