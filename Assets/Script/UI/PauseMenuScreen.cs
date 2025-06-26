using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Play()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMnue()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
