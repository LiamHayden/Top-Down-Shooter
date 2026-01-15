using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Variables
    public static float score;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
    }
    void Update()
    {
        UpdateScore();
    }

    // Destroy out of bounds Enemy is -1.
    // Destroy out of bounds Mini Boss is -3.
    // Detroying an enemy is +1.
    // Detroying a mini boss is +3.
    // Update score over time.
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
