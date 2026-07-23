using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DailyUIManager : MonoBehaviour
{
    [Header("デイリーパネル")]
    [SerializeField] private GameObject dailyPanel;

    [Header("ゲージ")]
    [SerializeField] private Slider foodSlider;
    [SerializeField] private Slider showerSlider;
    [SerializeField] private Slider stressSlider;
    [SerializeField] private Slider walkSlider;

    [Header("進捗テキスト")]
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text showerText;
    [SerializeField] private TMP_Text stressText;
    [SerializeField] private TMP_Text walkText;

    [Header("報酬ボタン")]
    [SerializeField] private Button rewardButton;
    [SerializeField] private TMP_Text rewardText;

    // デイリーを開く
    public void OpenDaily()
    {
        dailyPanel.SetActive(true);
        RefreshUI();
    }

    // デイリーを閉じる
    public void CloseDaily()
    {
        dailyPanel.SetActive(false);
    }

    // UI更新
    public void RefreshUI()
    {
        // ごはん
        foodSlider.value = DailyManager.Instance.foodProgress / 100f;
        foodText.text = $"{DailyManager.Instance.foodProgress:0}/100";

        // お風呂
        showerSlider.value = DailyManager.Instance.showerProgress / 100f;
        showerText.text = $"{DailyManager.Instance.showerProgress:0}/100";

        // ふれあい
        stressSlider.value = DailyManager.Instance.stressProgress / 100f;
        stressText.text = $"{DailyManager.Instance.stressProgress:0}/100";

        // 散歩
        walkSlider.value = (float)DailyManager.Instance.walkCount / 2f;
        walkText.text = $"{DailyManager.Instance.walkCount}/2";

        // 報酬ボタン
        rewardButton.interactable = DailyManager.Instance.CanReceiveReward();

        rewardText.text = DailyManager.Instance.rewardReceived
            ? "受取済み"
            : "報酬を受け取る";
    }

    // 報酬受け取り
    public void ReceiveReward()
    {
        DailyManager.Instance.ReceiveReward();
        RefreshUI();
    }
}