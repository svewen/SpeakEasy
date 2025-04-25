using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
