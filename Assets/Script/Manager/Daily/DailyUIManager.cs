using TMPro;
using UnityEngine;

public class DailyUIManager : MonoBehaviour
{
    [Header("デイリーパネル")]
    [SerializeField] private GameObject dailyPanel;

    [Header("ミッション")]
    [SerializeField] private TMP_Text loginText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text showerText;
    [SerializeField] private TMP_Text stressText;
    [SerializeField] private TMP_Text walkText;

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
        loginText.text =
            DailyManager.Instance.loginCompleted ?
            "✅ ログイン" :
            "⬜ ログイン";

        foodText.text =
            DailyManager.Instance.foodCompleted ?
            "✅ ごはん" :
            "⬜ ごはん";

        showerText.text =
            DailyManager.Instance.showerCompleted ?
            "✅ お風呂" :
            "⬜ お風呂";

        stressText.text =
            DailyManager.Instance.stressCompleted ?
            "✅ ふれあい" :
            "⬜ ふれあい";

        walkText.text =
            "散歩 {DailyManager.Instance.walkCount}/2";
    }
}