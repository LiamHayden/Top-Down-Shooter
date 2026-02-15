using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField] private float rotationSpeed = 5f;

    private Animator playerAnim;

    public float speed;
    private float horizontalInput;
    private float xRange = 18.17f;
    private Quaternion targetRotation;

    void Update()
    {
        Move();

        // Animation
        if (horizontalInput > 0)
        {
            playerAnim.SetFloat("Speed_f", 1.0f);
            targetRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (horizontalInput < 0)
        {
            playerAnim.SetFloat("Speed_f", 1.0f);
            targetRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 0.0f);
            targetRotation = Quaternion.Euler(0, 0, 0);
        }

        transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime * 200.0f
                );
    }

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    private void Move()
    {
        // Allow player to move left or right.
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);

        RestrictMovement();
    }

    // Stop the player from leaving the play area.
    private void RestrictMovement()
    {
        // Prevent the player from leaving the map.
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
