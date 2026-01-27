using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Variables
    public static bool isStarted;

    private bool waveEnding;

    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject waveCompletedCanvas;
    public TextMeshProUGUI waveEndScoreText;

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
    void Start()
    {
        isStarted = false;
    }

    private void EndWave()
    {
        StartCoroutine(ControlWaves());
    }

    // Wait 5 seconds and end wave after enemycount is reached
    private IEnumerator ControlWaves()
    {
        EnemySpawner.Instance.StopSpawning();

        yield return new WaitForSeconds(6);

        WaveManager.Instance.EndWave();

        yield return new WaitForSeconds(3);

        waveCompletedCanvas.SetActive(false);
        scoreCanvas.SetActive(false);

        EnemySpawner.Instance.enemyMax += 5;

        waveEnding = false;

        StartWave();
    }

    public void TryEndWave()
    {
        if (!waveEnding)
        {
            waveEnding = true;
            StartCoroutine(ControlWaves());
        }
    }

    public void StartWave()
    {
        isStarted = true;
        scoreCanvas.SetActive(true);

        EnemySpawner.Instance.StartSpawning();
    }
}
