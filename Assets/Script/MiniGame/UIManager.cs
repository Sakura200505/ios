using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Start UI")]
    public GameObject tapToStartPanel;
    public TMP_Text countdownText;

    [Header("Result UI")]
    public GameObject gameOverPanel;
    public GameObject clearPanel;

    [Header("Score")]
    public TMP_Text scoreText;
    public TMP_Text bestText;

    private bool gameStarted = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 0;

        tapToStartPanel.SetActive(true);
        countdownText.gameObject.SetActive(false);

        gameOverPanel.SetActive(false);
        clearPanel.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score : " + ScoreManager.Instance.score;
        bestText.text = "Best : " + ScoreManager.Instance.bestScore;

        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        gameStarted = true;

        tapToStartPanel.SetActive(false);

        countdownText.gameObject.SetActive(true);

        Time.timeScale = 1;

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.8f);

        countdownText.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowClear()
    {
        clearPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}