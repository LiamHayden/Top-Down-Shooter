using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    // Variables
    public GameObject menuCanvas;
    public GameObject scoreCanvas;

    // Start game
    public void StartGame()
    {
        GameManager.isStarted = true;
        menuCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
    }

    // Display controls

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
