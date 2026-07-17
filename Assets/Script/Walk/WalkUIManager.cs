using UnityEngine;
using TMPro;

public class WalkUIManager : MonoBehaviour
{
    [Header("散歩中UI")]
    [SerializeField] private GameObject walkPanel;

    [Header("ペットのUI")]
    [SerializeField] private GameObject petObject;

    [Header("タイマーのUI")]
    [SerializeField] private TMP_Text timerText;

    private void Update()
    {
        if (WalkManager.Instance.isWalking)
        {
            walkPanel.SetActive(true);
            petObject.SetActive(false);

            float remain = WalkManager.Instance.GetRemainingTime();

            int minute = Mathf.FloorToInt(remain / 60);
            int second = Mathf.FloorToInt(remain % 60);

            timerText.text = $"{minute:00}:{second:00}";
        }
        else
        {
            walkPanel.SetActive(false);
            petObject.SetActive(true);
        }
    }
}
