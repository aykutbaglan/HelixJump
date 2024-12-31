using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void GameResume()
    {
        Time.timeScale = 1f;
    }
    public static void GamePause()
    {
        Time.timeScale = 0f;
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}