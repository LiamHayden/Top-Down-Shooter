using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zRange = 18.0f;
    void Update()
    {
        DetroyOutOfBounds();
    }

    private void DetroyOutOfBounds()
    {
        if (transform.position.z < -zRange || transform.position.z > zRange)
        {
            Destroy(gameObject);

            // Decrease score
            if (CompareTag("Enemy"))
            {
                ScoreManager.score -= 1;
            } else if (CompareTag("Mini Boss"))
            {
                ScoreManager.score -= 3;
            }
        }
    }
}
