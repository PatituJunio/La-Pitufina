using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class pitufinaController : MonoBehaviour
{
    [Header("Movimiento")]
    public float acceleration = 20f;
    public float deceleration = 30f;
    public float maxSpeed = 5f;
    public float runMultiplier = 1.5f;

    [Header("Salto")]
    public float jumpForce = 12f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;




    [Header("Sonidos")]
    public AudioClip jumpSound;


    private Rigidbody2D rb;
    private float currentSpeed = 0f;
    private bool isGrounded;
    float  velocidad = 0.01f;

    private AudioSource playerAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Esto hace que rb ahora sea el rigidbody del objeto que tiene el script
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Entrada horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift); // Shift para correr

        // Velocidad objetivo
        float targetSpeed = moveInput * maxSpeed;
        if (isRunning) targetSpeed *= runMultiplier;

        // Aceleración y desaceleración suave
        if (Mathf.Abs(targetSpeed) > Mathf.Abs(currentSpeed))
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        else
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, deceleration * Time.deltaTime);

        // Aplicar velocidad horizontal
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        // Verificar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Salto con barra espaciadora
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            float finalJumpForce = jumpForce;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                finalJumpForce *= 1.5f;
            }

            rb.velocity = new Vector2(rb.velocity.x, finalJumpForce);

          
            if (playerAudio != null && jumpSound != null)
            {
                playerAudio.PlayOneShot(jumpSound, 0.8f);
            }
            else
            {
                Debug.LogWarning("Falta el AudioSource o el AudioClip en Pitufina.");
            }
        }




        // invertir sprite según dirección
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Mirando a la derecha
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Mirando a la izquierda
                                                          // aca termina la parte que invierte el script

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, velocidad, 0));
        }

        

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            GameManager.instance.PerderVida(false); // Llama al controlador
        }
    }



}