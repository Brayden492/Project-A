using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60f;
    [SerializeField] GameObject failedScreen;
    [SerializeField] TMP_Text timerText;

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        timerText.text = Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            LoseGame();
        }
    }

    void LoseGame()
    {
        failedScreen.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

