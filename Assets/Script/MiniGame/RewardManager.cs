using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameRewardManager : MonoBehaviour
{
    public static MiniGameRewardManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void FinishGame(bool clear)
    {
        if (clear)
        {
            // 経験値
            StatusManager.Instance.AddExp(20);

            // アイテム
            // ItemManager.Instance.GetRandomItem();
        }

        SceneManager.LoadScene("MainScene");
    }
}