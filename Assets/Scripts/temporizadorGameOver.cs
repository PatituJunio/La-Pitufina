using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Necesario para controlar textos de TextMeshPro

public class TemporizadorGameOver : MonoBehaviour
{
    [Header("Configuración de Escena")]
    [SerializeField] private string nombreEscenaACargar = "Home";
    [SerializeField] private float tiempoEspera = 50f;

    [Header("Componentes de UI")]
    [SerializeField] private TextMeshProUGUI textoContador; // Arrastra tu texto aquí
    [SerializeField] private string mensajeFormato = "El juego iniciará en: {0}s";

    void Start()
    {
        if (textoContador == null)
        {
            Debug.LogError("¡No has asignado el componente de texto en el Inspector!");
            return;
        }

        StartCoroutine(EsperarYContarEscena());
    }

    IEnumerator EsperarYContarEscena()
    {
        float tiempoRestante = tiempoEspera;

        // Bucle que se ejecuta segundo a segundo hasta llegar a cero
        while (tiempoRestante > 0)
        {
            // Mathf.CeilToInt redondea hacia arriba para que muestre 50, 49, 48... sin decimales
            textoContador.text = string.Format(mensajeFormato, Mathf.CeilToInt(tiempoRestante));

            // Espera exactamente 1 segundo antes de continuar el bucle
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
        }

        // Asegura que muestre 0 antes de cambiar
        textoContador.text = string.Format(mensajeFormato, 0);

        // Carga la nueva escena
        SceneManager.LoadScene(nombreEscenaACargar);
    }
}
