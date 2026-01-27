using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    // Variables
    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject howToCanvas;

    // Start game
    public void StartGame()
    {
        GameManager.isStarted = true;
        GameManager.Instance.StartWave();
        menuCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
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

    public void DisplayHowToView()
    {
        howToCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void HideHowToView()
    {
        howToCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
