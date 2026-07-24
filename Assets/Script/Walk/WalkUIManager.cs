using UnityEngine;
using TMPro;

public class WalkUIManager : MonoBehaviour
{
    [Header("散歩中UI")]
    [SerializeField] private GameObject walkPanel;

    [Header("ペットUI")]
    [SerializeField] private GameObject petObject;

    [Header("タイマー")]
    [SerializeField] private TMP_Text timerText;

    private void Update()
    {
        // WalkManagerがまだ生成されていない場合
        if (WalkManager.Instance == null)
            return;

        bool walking = WalkManager.Instance.isWalking;

        walkPanel.SetActive(walking);
        petObject.SetActive(!walking);

        if (!walking)
            return;

        float remain = WalkManager.Instance.GetRemainingTime();

        int minute = Mathf.FloorToInt(remain / 60f);
        int second = Mathf.FloorToInt(remain % 60f);

        timerText.text = $"{minute:00}:{second:00}";
    }
}