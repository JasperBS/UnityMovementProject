using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;             
    public float moveSpeed = 5f;             
    public float groundCheckDistance = 0.3f; 
    public float groundCheckRadius = 0.3f;   
    public LayerMask groundLayer;            

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        isGrounded = IsGrounded();

        HandleMovement();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        bool hitGround = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer);

        if (hitGround && rb.velocity.y <= 0f)
        {
            return true;
        }

        return false;
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        Vector3 currentVelocity = rb.velocity;
        currentVelocity.x = move.x * moveSpeed;
        currentVelocity.z = move.z * moveSpeed;

        rb.velocity = currentVelocity;
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
