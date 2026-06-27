using UnityEngine;

public class ControlTD : MonoBehaviour
{
    [Header("Movimiento")]
    public float acceleration = 20f;
    public float deceleration = 30f;
    public float maxSpeed = 5f;
    public float runMultiplier = 1.5f;

    private Rigidbody2D rb;
    private Vector2 currentVelocity;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Desactiva la gravedad para top-down
        rb.gravityScale = 0;
    }

    void Update()
    {
        // Entrada en ambas direcciones
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
     
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Vector de entrada normalizado
        Vector2 input = new Vector2(moveX, moveY).normalized;

        // Velocidad objetivo
        float targetSpeed = maxSpeed * (isRunning ? runMultiplier : 1f);
        Vector2 targetVelocity = input * targetSpeed;

        // Aceleración y desaceleración suave en X
        currentVelocity.x = Mathf.MoveTowards(
            currentVelocity.x,
            targetVelocity.x,
            (Mathf.Abs(targetVelocity.x) > Mathf.Abs(currentVelocity.x) ? acceleration : deceleration) * Time.deltaTime
        );

        // Aceleración y desaceleración suave en Y
        currentVelocity.y = Mathf.MoveTowards(
            currentVelocity.y,
            targetVelocity.y,
            (Mathf.Abs(targetVelocity.y) > Mathf.Abs(currentVelocity.y) ? acceleration : deceleration) * Time.deltaTime
        );

        // Aplicar velocidad
        rb.velocity = currentVelocity;

        // Voltear sprite según dirección horizontal
        if (moveX > 0)
        {
            sr.flipX = false; // mirando a la derecha
        }
        else if (moveX < 0)
        {
            sr.flipX = true;  // mirando a la izquierda
        }
    }
}