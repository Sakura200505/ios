using TMPro;
using UnityEngine;

public class WalkMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject walkMenuPanel;
    [SerializeField] private TMP_Text remainingText;
    [SerializeField] private TMP_Text timeText;

    public void OpenMenu()
    {
        walkMenuPanel.SetActive(true);

        // c‚è‚ÌU•à‰ñ”‚ğ•\¦
        int remainingWalk = DailyManager.Instance.GetRemainingWalk();

        remainingText.text = $"‚ ‚Æ{remainingWalk}‰ñ";

        // U•àŠÔ‚ğ•\¦
        timeText.text = "U•àŠÔF–ñ30•b";
    }

    public void CloseMenu()
    {
        walkMenuPanel.SetActive(false);
    }

    public void StartWalk()
    {
        // U•à‚Å‚«‚é‚©Šm”F
        if (!WalkManager.Instance.CanWalk())
        {
            Debug.Log("Œ»İU•à‚Å‚«‚È‚¢‚æI");
            return;
        }

        WalkManager.Instance.StartWalk();

        CloseMenu();
    }
}