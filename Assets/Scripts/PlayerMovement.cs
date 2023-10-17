using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100.0f;
    private Rigidbody2D rb2d;

    private Vector2 movement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new(horizontalInput, (verticalInput*-1));
    }

    void FixedUpdate()
    {
        float rotation = -movement.x * rotationSpeed * Time.deltaTime;

        rb2d.rotation += rotation;

        Vector2 moveDirection = new(0, movement.y * moveSpeed);

        moveDirection = transform.TransformDirection(moveDirection);

        rb2d.velocity = moveDirection;
    }
}
