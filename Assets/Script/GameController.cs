using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;



    public void GameOver()
    {
        Time.timeScale = 0f;//pause the game
        gameOverScreen.Setup();
    }


}
