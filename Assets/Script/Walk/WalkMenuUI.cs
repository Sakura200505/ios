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

        // ‚Æ‚è‚ ‚¦‚¸ŒÅ’è•\¦
        remainingText.text = "‚ ‚Æ2‰ñ";

        timeText.text = "U•àŠÔF–ñ30•ª";
    }

    public void CloseMenu()
    {
        walkMenuPanel.SetActive(false);
    }

    public void StartWalk()
    {
        WalkManager.Instance.StartWalk();
        CloseMenu();
    }
}