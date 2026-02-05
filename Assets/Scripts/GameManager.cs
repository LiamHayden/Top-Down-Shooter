using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Variables
    public bool isStarted;

    private bool waveEnding;

    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject waveCompletedCanvas;
    public TextMeshProUGUI waveEndScoreText;

    // enums for game states
    public enum GameState
    {
        Menu,
        Playing
    }

    public GameState CurrentState { get; private set; }

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

    public void EndGame()
    {
        isStarted = false;
        menuCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        waveEndScoreText.text = "Final Score: " + ScoreManager.score;
        //waveCompletedCanvas.SetActive(true);
    }

    // if the player gets >= -10 score end the game.
    void Update()
    {
        if (ScoreManager.score <= -10)
        {
            EndGame();
            ReturnToHome();
        }
    }

    private void ReturnToHome()
    {
        EnemySpawner.Instance?.StopSpawning();

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }

    public void ShowMenu()
    {
        // Set game state
        CurrentState = GameState.Menu;

        // stop spawning
        EnemySpawner.Instance?.StopSpawning();

        // Ensure wait for second is deactive
        Time.timeScale = 0f;

        // Show menu canvas
        menuCanvas.SetActive(true);

    }


    // Start game
    public void StartGame()
    {
        // Change game state
        CurrentState = GameState.Playing;

        // Ensure wait for second is active
        Time.timeScale = 1f;

        // Show score canvas and change isStarted
        isStarted = true;

        //StartWave();
        menuCanvas.SetActive(false);
        scoreCanvas.SetActive(true);

        // Start spawning
        EnemySpawner.Instance.StartSpawning();
    }

    // Quit game
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
