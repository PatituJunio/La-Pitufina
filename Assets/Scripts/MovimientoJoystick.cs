using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJoystick : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb2d;

    // Referencia a tu Joystick (puede ser del Joystick Pack o del Input System)
    // Cambia "VariableJoystick" por el nombre de la clase de tu joystick
    public VariableJoystick joystick;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Obtener el valor del Joystick
        Vector2 inputVector = new Vector2(joystick.Horizontal, joystick.Vertical);

        // Mover el Rigidbody2D alterando su velocidad
        rb2d.velocity = inputVector * moveSpeed;
    }
}
