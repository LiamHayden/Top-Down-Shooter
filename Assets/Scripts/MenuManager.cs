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
