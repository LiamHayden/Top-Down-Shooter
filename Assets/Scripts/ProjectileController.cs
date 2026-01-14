using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Variables
    private float zRange = 18.2f;

    void FixedUpdate()
    {
        FireProjectile();
        DestroyOutOfBounds();
    }

    // Fire projectile
    private void FireProjectile()
    {
        if (ProjectileManager.isFired)
        {
            Debug.Log("Projectile fired.");
            transform.Translate(Vector3.forward * Time.deltaTime * 5.0f); ;
        }
    }

    // Detroy game object when out of bounds
    private void DestroyOutOfBounds()
    {
        if (transform.position.z >= zRange)
        {
            Destroy(gameObject);
        }
    }

    // Destroy projectile and Enemy on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
