using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject player;
    public static bool isFired = false;

    void Update()
    {
        if (GameManager.Instance.isStarted)
        {
            FireProjectile();
        }
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
            Instantiate(projectilePrefab, new Vector3(player.transform.position.x, 1.0f, player.transform.position.z), projectilePrefab.transform.rotation);
        }
    }

}
