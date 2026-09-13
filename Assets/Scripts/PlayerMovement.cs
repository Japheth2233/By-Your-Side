using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D playerBody;
    private Vector2 direction;
    private bool isGrounded;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            0.2f,
            groundLayer
        );
    }

    void FixedUpdate()
    {
        playerBody.linearVelocity =
            new Vector2(direction.x * speed, playerBody.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            playerBody.linearVelocity =
                new Vector2(playerBody.linearVelocity.x, jumpForce);
        }
    }
}