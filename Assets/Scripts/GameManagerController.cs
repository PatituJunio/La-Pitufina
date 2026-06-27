using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance { get; private set; }

    [Header("Configuración de Datos")]
    public int score = 0;
    public float masterVolume = 1.0f;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip jumpSound;
    public AudioClip moscaSound;
    public AudioClip barritaSound;
    public AudioClip aplausoSound;
    public AudioClip loboSound;

    [Header("Componentes de Audio")]
    private AudioSource musicSource;
    private AudioSource sfxSource;


    [Header("Estadísticas")]
    public  int vidas = 3;
    public  int puntos = 0;
    public  int energia = 0;
    public bool tieneAnteojos=false;

    private string escenaActual; // Guarda el nombre del nivel actual


    [Header("UI")]
    public TMP_Text textoVidas;
    public TMP_Text textoPuntos;
    public TMP_Text textoEnergia;



    private void Awake()
    {
        // Patrón Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Configura los componentes de audio internamente
        ConfigureAudioSources();
    }

    private void Start()
    {
        // Reproduce la música de fondo automáticamente al iniciar el juego
        //PlayBackgroundMusic();
    }

    private void ConfigureAudioSources()
    {
        // Crea dos fuentes de audio separadas para música y efectos
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Configuración por defecto
        musicSource.loop = true;
        musicSource.volume = masterVolume;
        sfxSource.volume = masterVolume;
    }

    // --- MÉTODOS DE AUDIO ---

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            // PlayOneShot evita que el sonido se corte si se salta muy rápido
            sfxSource.PlayOneShot(jumpSound);
        }
    }
    public void PlayLoboSound()
    {
        if (jumpSound != null)
        {
            // PlayOneShot evita que el sonido se corte si se salta muy rápido
            sfxSource.PlayOneShot(loboSound);
        }
    }


    public void PlayMoscaSound()
    {
        if (moscaSound != null)
        {
            // PlayOneShot evita que el sonido se corte si se salta muy rápido
            sfxSource.PlayOneShot(moscaSound);
        }
    }


    public void PlayBarritaSound()
    {
        if (moscaSound != null)
        {
            // PlayOneShot evita que el sonido se corte si se salta muy rápido
            sfxSource.PlayOneShot(barritaSound);
        }
    }


    public void PlayAplausoSound()
    {
        if (moscaSound != null)
        {
            // PlayOneShot evita que el sonido se corte si se salta muy rápido
            sfxSource.PlayOneShot(aplausoSound);
        }
    }

    public void UpdateVolume(float newVolume)
    {
        masterVolume = newVolume;
        musicSource.volume = masterVolume;
        sfxSource.volume = masterVolume;
    }

    // --- MÉTODOS DE PUNTOS ---

      
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        
    }


    public void sumarEnergia(int cantidad)
    {
        energia += cantidad;
        if (energia == 3)
        {
            energia = 0;
            vidas++;
        }
        
    }
    public void ActivarAnteojos()
    {
        tieneAnteojos = true;
        PlayAplausoSound();
        // "Nivel2" debe llamarse exactamente igual que tu archivo de escena
        SceneManager.LoadScene("Nivel2");
    }
    public void PerderVida(bool enAgua)
    {
        vidas--;
        
        
        if (vidas > 0)
        {
            Debug.Log("Vidas restantes: " + vidas + ". Reiniciando nivel...");
            ReiniciarNivel();
        }
        else
        {
            Debug.Log("¡Game Over!");
            CargarGameOver();
        }
    }



    private void OnEnable()
    {
        // Nos suscribimos al evento de Unity que detecta cuando cambia una escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Este método se ejecuta automáticamente CADA VEZ que se carga cualquier escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si no es el menú principal, guardamos el nombre del nivel para saber dónde reiniciar
        if (scene.name != "MenuPrincipal" && scene.name != "GameOver")
        {
            escenaActual = scene.name;
        }
    }

    // --- LÓGICA DE VIDAS Y REINICIO ---

   

    private void ReiniciarNivel()
    {
        // Restablecemos la energía al reiniciar el nivel
        energia = 100;

        // Recarga la escena guardada automáticamente
        SceneManager.LoadScene(escenaActual);
    }

    private void CargarGameOver()
    {
        // Restablecemos los valores por defecto para cuando vuelva a jugar
        vidas = 3;
        puntos = 0;
        energia = 100;

        // Carga una pantalla de Game Over (debes crear esta escena)
        SceneManager.LoadScene("GameOver");
    }



}