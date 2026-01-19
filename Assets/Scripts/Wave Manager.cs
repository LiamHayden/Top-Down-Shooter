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
        waveEndScoreText.text = "Score: " + ScoreManager.score;
    }

    public void DisplayWaveCanvas()
    {
        waveCompletedCanvas.SetActive(true);
    }
}
