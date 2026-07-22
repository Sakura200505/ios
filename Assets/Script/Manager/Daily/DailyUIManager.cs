using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DailyUIManager : MonoBehaviour
{
    [Header("デイリーパネル")]
    [SerializeField] private GameObject dailyPanel;

    [Header("ログイン")]
    [SerializeField] private TMP_Text loginText;

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
        // ログイン
        loginText.text = DailyManager.Instance.loginCompleted
            ? "✅ ログイン"
            : "⬜ ログイン";

        // ごはん
        foodSlider.value = StatusManager.Instance.hunger / 100f;
        foodText.text = $"{StatusManager.Instance.hunger:0}/100";

        // お風呂
        showerSlider.value = StatusManager.Instance.clean / 100f;
        showerText.text = $"{StatusManager.Instance.clean:0}/100";

        // ふれあい（ストレスは少ないほど良い）
        float stressValue = 100f - StatusManager.Instance.stress;
        stressSlider.value = stressValue / 100f;
        stressText.text = $"{stressValue:0}/100";

        // 散歩
        walkSlider.value = (float)DailyManager.Instance.walkCount / 2f;
        walkText.text = $"{DailyManager.Instance.walkCount}/2";

        // 報酬ボタン
        rewardButton.interactable = DailyManager.Instance.CanReceiveReward();

        if (DailyManager.Instance.rewardReceived)
        {
            rewardText.text = "受取済み";
        }
        else
        {
            rewardText.text = "報酬を受け取る";
        }
    }

    // 報酬受け取り
    public void ReceiveReward()
    {
        DailyManager.Instance.ReceiveReward();
        RefreshUI();
    }
}