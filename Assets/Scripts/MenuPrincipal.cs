using UnityEngine;
using UnityEngine.SceneManagement; // Requerido para cambiar de escena

public class MenuPrincipal : MonoBehaviour
{
    // Este método lo llamará el botón "Iniciar Juego"
    public void IniciarJuego()
    {
        GameManagerController.instance.PlayBackgroundMusic();
        // "Nivel1" debe llamarse exactamente igual que tu archivo de escena
        SceneManager.LoadScene("Nivel1");
    }


    // Opcional: Método para cerrar el juego si agregas un botón de salir
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado"); // Solo se ve en el editor de Unity
    }
}
