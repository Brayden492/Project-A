using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        GameComplete.gameComplete = false;

        SceneManager.LoadScene("Game");
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        GameComplete.gameComplete = false;
        SceneManager.LoadScene("MainMenu");
    }

    //public void Retry()
    //{

    //    Time.timeScale = 1f;
    //    GameComplete.gameComplete = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //    SceneManager.LoadScene("Game");
    //}
}