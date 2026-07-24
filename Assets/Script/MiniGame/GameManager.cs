using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver;

    void Awake()
    {
        Instance = this;
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
}