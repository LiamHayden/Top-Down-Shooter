using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject player;
    public static bool isFired = false;

    void Update()
    {
        FireProjectile();
    }

    // Fire projectile forward
    private void FireProjectile()
    {
        // Change isFired state
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFired = true;
            Debug.Log("Space pressed");

            // Instaitate new projectile
            Instantiate(projectilePrefab, player.transform.position, projectilePrefab.transform.rotation);
        }
    }

}
