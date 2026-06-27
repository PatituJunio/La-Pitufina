using Cinemachine;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar la escena
using UnityEngine.UI; // Si usas UI tradicional, o usa TMPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton

    [Header("Estadísticas")]
    public static int vidas = 3;
    public static int puntos = 0;
    public static int energia = 0;

    [Header("UI")]
    public TMP_Text textoVidas;
    public TMP_Text textoPuntos;
    public TMP_Text textoEnergia;
    public Camera CamaraPrincipal;
    public GameObject anteojosUI;
    public GameObject btnIniciarJuegoUI;
    public GameObject btnSalirJuegoUI;





    [Header("Sonidos")]
    public AudioClip comiendoBarritaSound;
    public AudioClip lobocomiendoaPituSound;
    public AudioClip AgarrandoAnteojosPituSound;
    public AudioClip comiendoMoscaSound;

    private AudioSource playerAudio;


    private void Awake()
    {
        // Configurar el Singleton
        if (instance == null)
        {
            instance = this;
            playerAudio = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena

        }
        else
        {
            Destroy(gameObject);
        }
       
        Debug.Log(comiendoBarritaSound);
    }

    private void Start()
    {
        ActualizarUI();
        playerAudio = GetComponent<AudioSource>();
        CamaraPrincipal = GetComponent<Camera>();
     }

public void PerderVida(bool enAgua)
    {
        vidas--;
        ActualizarUI();

        if (playerAudio != null && lobocomiendoaPituSound != null)
        {
            playerAudio.PlayOneShot(lobocomiendoaPituSound, 2.8f);
        }
        else
        {
            Debug.LogWarning("Falta el AudioSource o el AudioClip para el lobo quita vida.");
        }


        if (vidas <= 0 ||  enAgua)
        {
            ReiniciarJuego();
        }
    }
    public void ActivarCamara2()
    {
        if (CamaraPrincipal != null)
        {
            CamaraPrincipal.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Falta la camara principal.");
        }

    }

    public void DesActivarCamara2()
    {
        if (CamaraPrincipal != null)
        {
            CamaraPrincipal.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Falta la camara principal.");
         }
        
    }
    public void sumarEnergia(int cantidad)
    {
        energia += cantidad;

        Debug.Log(playerAudio);
        Debug.LogWarning("Falta el AudioSource o el AudioClip para comer barrita. comiendoBarritaSound");
        if (playerAudio != null && comiendoBarritaSound != null)
        {
            playerAudio.PlayOneShot(comiendoBarritaSound, 5f);
        }
        else
        {
            Debug.LogWarning("Falta el AudioSource o el AudioClip para comer barrita. comiendoBarritaSound");
        }
        if (energia == 3){
            energia = 0;
            vidas ++ ;
        }
        ActualizarUI();
    }
    public void ActivarAnteojos()
    {
        
        if (playerAudio != null && AgarrandoAnteojosPituSound != null)
        {
            playerAudio.PlayOneShot(AgarrandoAnteojosPituSound, 0.8f);



        }
        else
        {
            Debug.LogWarning("Falta el AudioSource o el AudioClip para AgarrandoAnteojosPituSound.");
        }

            anteojosUI.SetActive(true);

        CargarNivel("Nivel2", "Nivel1");
    }
 

    void ActualizarUI()
    {
        if (textoVidas.text != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }

        if (textoPuntos.text != null)
        {
            textoPuntos.text = "Puntos: " + puntos;
        }

        if (textoEnergia.text != null)
        {
            textoEnergia.text = "Energia: " + energia;
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(0);
    }


    public void CargarNivel(string nombreEscena, string descargarEscena = "")

    {

        if (!string.IsNullOrEmpty(descargarEscena))
        {
            SceneManager.UnloadSceneAsync(descargarEscena);
        }
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Additive);
       
        
       
    }


    // Esta función se llamará al pulsar el botón
    public void BotonIniciarJuego()
    {
        Console.Write("CArgando el juego");
        btnIniciarJuegoUI.gameObject.SetActive(false);
        btnSalirJuegoUI.gameObject.SetActive(false);
        SceneManager.LoadScene("Nivel1", LoadSceneMode.Additive);
    }
    public void BotonSalirJuego()
    {
        Application.Quit();
    }
}
