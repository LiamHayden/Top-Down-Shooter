using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float zRange = 18.2f;
    public bool isFired = false;
    void Update()
    {
        FireProjectile();
        DestroyOutOfBounds();
    }

    // Fire projectile forward
    private void FireProjectile()
    {
        // Change isFired state
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isFired = true;
        }

        // Fire projectile
        if (isFired)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
        }
    }

    private void DestroyOutOfBounds()
    {
        // Detroy game object when out of bounds
        if (transform.position.z >= zRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy projectile on collision with enemy
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
