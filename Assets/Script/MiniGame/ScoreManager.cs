using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;

    public int bestScore;

    void Awake()
    {
        Instance = this;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void AddScore()
    {
        score++;
    }

    public void SaveBest()
    {
        if (score > bestScore)
        {
            bestScore = score;

            PlayerPrefs.SetInt("BestScore", bestScore);

            PlayerPrefs.Save();
        }
    }
}