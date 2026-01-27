using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    // Variables
    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject waveCompletedCanvas;
    public TextMeshProUGUI waveEndScoreText;
    public TextMeshProUGUI waveCompletedText;

    public float waveNumber = 0.0f;
    public bool isWaveOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Display menu and hide score canvas
    public void EndWave()
    {
        // Display end wave canvas
        DisplayWaveCanvas();

        // Update end score
        UpdateWaveEndScore();
    }

    private void UpdateWaveEndScore()
    {
        waveNumber++;
        waveEndScoreText.text = "Score: " + ScoreManager.score;
        waveCompletedText.text = "WAVE " + waveNumber + " COMPLETED";
    }

    public void DisplayWaveCanvas()
    {
        waveCompletedCanvas.SetActive(true);
    }
}
