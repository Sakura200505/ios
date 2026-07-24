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
    [SerializeField] private Button foodButton;
    [SerializeField] private Button showerButton;
    [SerializeField] private Button stressButton;
    [SerializeField] private Button walkButton;

    [SerializeField] private Slider rewardSlider;
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
        Debug.Log($"UI ID:{DailyManager.Instance.GetInstanceID()} food={DailyManager.Instance.foodProgress}");

        DailyManager daily = DailyManager.Instance;

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

        // 各ミッション受け取りボタン
        foodButton.interactable =
            DailyManager.Instance.foodProgress >= 100 && !DailyManager.Instance.foodReceived;

        showerButton.interactable =
            DailyManager.Instance.showerProgress >= 100 && !DailyManager.Instance.showerReceived;

        stressButton.interactable =
            DailyManager.Instance.stressProgress >= 100 && !DailyManager.Instance.stressReceived;

        walkButton.interactable =
            DailyManager.Instance.IsWalkComplete() && !DailyManager.Instance.walkReceived;

        // 最終報酬ゲージ
        rewardSlider.value = DailyManager.Instance.rewardProgress / 100f;

        // 最終報酬ボタン
        rewardButton.interactable = DailyManager.Instance.CanReceiveReward();

        rewardText.text = DailyManager.Instance.rewardReceived
            ? "受取済み"
            : "ゲームチケットを受け取る";
    }

    //ご飯の報酬を受け取る処理
    public void ReceiveFood()
    {
        DailyManager.Instance.ReceiveFood();
        RefreshUI();
    }

    //シャワーの報酬を受け取る処理
    public void ReceiveShower()
    {
        DailyManager.Instance.ReceiveShower();
        RefreshUI();
    }

    //触れ合いの報酬を受け取る処理
    public void ReceiveStress()
    {
        DailyManager.Instance.ReceiveStress();
        RefreshUI();
    }

    //散歩の報酬を受け取る処理
    public void ReceiveWalk()
    {
        DailyManager.Instance.ReceiveWalk();
        RefreshUI();
    }

    // 最終報酬受け取り
    public void ReceiveReward()
    {
        DailyManager.Instance.ReceiveReward();
        RefreshUI();
    }
}