using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loboController : MonoBehaviour
{
  
    [Header("Referencias")]
    public Transform player;

    [Header("Configuración")]
    public float rotationSpeed = 5f;
    [SerializeField]
    float velocidad = 0.5f;
    void Update()
    {
        if (player == null) return;

        // 1. Calculamos el vector de dirección desde el enemigo hacia el jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // 2. Usamos el Producto Punto para verificar la orientación
        // El resultado es > 0 si el jugador está adelante, < 0 si está atrás
        float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);

        // Si el jugador está detrás (dotProduct < 0), nos giramos
        if (dotProduct < 0)
        {
            RotateTowardsPlayer(directionToPlayer);
        }

        transform.Translate(new Vector3(velocidad * Time.deltaTime, 0, 0));
    }

    void RotateTowardsPlayer(Vector3 direction)
    {
        // Creamos la rotación necesaria para mirar al objetivo
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Suavizamos la rotación usando Slerp (Interpolación esférica)
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}


