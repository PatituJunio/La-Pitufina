using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class CercaniaController : MonoBehaviour
{


    
    [SerializeField] private CinemachineVirtualCamera zoomCamera;

    // Nivel de zoom al entrar
    [SerializeField] private float zoomSize = 3f;
    // Nivel de zoom por defecto (al salir)
    [SerializeField] private float defaultSize = 5f;
        
       

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Cambiar la prioridad de la cámara para que sea la activa
            zoomCamera.Priority = 11;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Restaurar prioridad menor
            zoomCamera.Priority = 9;
        }
    }
}
