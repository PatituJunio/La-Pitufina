using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar la escena
using UnityEngine.UI; // Si usas UI tradicional, o usa TMPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton

    [Header("Estadísticas")]
    public int vidas = 3;
    public int puntos = 0;
    public int energia = 10;

    [Header("UI")]
    public TMP_Text textoVidas;
    public TMP_Text textoPuntos;
    public TMP_Text textoEnergia;

    private void Awake()
    {
        // Configurar el Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ActualizarUI();
    }

    public void PerderVida(bool enAgua)
    {
        vidas--;
        ActualizarUI();
        if (vidas <= 0 ||  enAgua)
        {
            ReiniciarJuego();
        }
    }

    public void sumarEnergia(int cantidad)
    {
        energia += cantidad;
        ActualizarUI();
    }
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoVidas.text != null) textoVidas.text = "Vidas: " + vidas;
        if (textoPuntos.text != null) textoPuntos.text = "Puntos: " + puntos;
        if (textoEnergia.text != null) textoEnergia.text = "Energia: " + energia;
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
