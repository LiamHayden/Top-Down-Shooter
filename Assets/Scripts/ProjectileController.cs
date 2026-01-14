using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void FixedUpdate()
    {
        FireProjectile();
    }

    // Fire projectile
    private void FireProjectile()
    {
        if (ProjectileManager.isFired)
        {
            Debug.Log("Projectile fired.");
            transform.Translate(Vector3.forward * Time.deltaTime * 15.0f); ;
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
