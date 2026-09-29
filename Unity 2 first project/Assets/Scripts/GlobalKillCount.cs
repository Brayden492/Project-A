using UnityEngine;

public class GlobalKillCount : MonoBehaviour
{
    public static int killCount = 0;

    [SerializeField] TMPro.TMP_Text killDisplay;

    void Start()
    {
        killCount = 0;
    }

    void Update()
    {
        killDisplay.text = "Kills: " + killCount;
    }
}
