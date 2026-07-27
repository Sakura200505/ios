using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public bool isGameOver;
    public bool isGameStarted;

    private void Awake()
    {
        Instance = this;
    }

    // MainSceneのボタンから呼ぶ
    public void StartMiniGame()
    {
        if (TicketManager.Instance.UseTicket())
        {
            SceneManager.LoadScene("MiniGameScene");
        }
        else
        {
            Debug.Log("チケットがありません");
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        ScoreManager.Instance.SaveBest();
        UIManager.Instance.ShowGameOver();
    }

    public void GameClear()
    {
        if (isGameOver) return;

        isGameOver = true;

        ScoreManager.Instance.SaveBest();
        UIManager.Instance.ShowClear();
    }

    public void FinishMiniGame(bool isClear)
    {
        if (isClear)
        {
            // 経験値やアイテム付与
            // StatusManager.Instance.AddExp(20);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}