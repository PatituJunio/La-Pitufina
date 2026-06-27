using UnityEngine;

public class BotonAccion : MonoBehaviour
{
    // Método para el botón de Saltar
    public void PresionarSaltar()
    {
        if (GameManagerController.instance != null)
        {
            GameManagerController.instance.PlayJumpSound();
            Debug.Log("¡Sonido de salto ejecutado desde el botón!");
        }
    }

    // Método para el botón de Sumar Puntos
    public void PresionarSumarPuntos()
    {
        if (GameManagerController.instance != null)
        {
            GameManagerController.instance.SumarPuntos(10);
            Debug.Log("¡Puntos sumados! Total: " + GameManagerController.instance.score);
        }
    }
}
