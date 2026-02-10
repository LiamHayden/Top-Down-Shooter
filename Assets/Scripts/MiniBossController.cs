using UnityEngine;

public class MiniBossController : MonoBehaviour
{
    public ParticleSystem largeExplosionParticle;
    public float lives = 3;

    // Destroy projectile and Enemy Mini Boss on collision after all lives are depleted.
    private void OnTriggerEnter(Collider other)
    {
        // Decrease lives on projectile hit
        if (other.CompareTag("Projectile"))
        {
            lives--;
            Destroy(other.gameObject);
        }

        // Destroy Mini Boss if lives are 0 or less
        if (lives <= 0)
        {
            Instantiate(largeExplosionParticle, transform.position, largeExplosionParticle.transform.rotation);

            Destroy(gameObject);

            // Update score
            ScoreManager.score += 3;
        }
    }
}
