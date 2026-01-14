using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public Rigidbody rb;

    public float speed;
    private float horizontalInput;
    private float xRange = 18.17f;
    void Update()
    {
        Move();
    }
    private void Move()
    {

        // Allow player to move left or right.
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Prevent the player from leaving the map.
        if(transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
