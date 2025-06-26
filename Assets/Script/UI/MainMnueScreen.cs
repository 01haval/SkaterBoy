using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMnueScreen : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Editor
    #endif
    }
}
