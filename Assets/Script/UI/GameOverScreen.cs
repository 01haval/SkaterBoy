using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    Player player;
    TMP_Text distanceText;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1f; // Resume the game time
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
