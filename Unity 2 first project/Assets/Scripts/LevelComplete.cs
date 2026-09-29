using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject failedScreen;
    [SerializeField] int totalEnemies = 3;
    [SerializeField] int requiredKills = 3;
    [SerializeField] TMPro.TMP_Text victoryKillResultText;
    [SerializeField] TMPro.TMP_Text failedKillResultText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryKillResultText.text = "You managed to kill " + GlobalKillCount.killCount +
                " out of " + totalEnemies + " enemies.";

            failedKillResultText.text = "You managed to kill " + GlobalKillCount.killCount +
                " out of " + totalEnemies + " enemies.";

            if (GlobalKillCount.killCount >= requiredKills)
            {
                victoryScreen.SetActive(true);
            }
            else
            {
                failedScreen.SetActive(true);
            }

            Time.timeScale = 0f;

            GameComplete.gameComplete = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
