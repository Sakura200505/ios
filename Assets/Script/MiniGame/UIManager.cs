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

    // ゲームが実際にプレイ中か
    public bool IsPlaying { get; private set; }

    // カウントダウンのコルーチンを管理
    private Coroutine countdownCoroutine;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 0;

        IsPlaying = false;

        tapToStartPanel.SetActive(true);
        countdownText.gameObject.SetActive(false);

        gameOverPanel.SetActive(false);
        clearPanel.SetActive(false);
    }

    void Update()
    {
        // スコア表示
        if (ScoreManager.Instance != null)
        {
            scoreText.text = "Score : " + ScoreManager.Instance.score;
            bestText.text = "Best : " + ScoreManager.Instance.bestScore;
        }

        // ゲーム開始前にタップされたらカウントダウン開始
        if (!IsPlaying && countdownCoroutine == null &&
            Input.GetMouseButtonDown(0))
        {
            countdownCoroutine = StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        tapToStartPanel.SetActive(false);

        countdownText.gameObject.SetActive(true);

        // カウントダウン中はゲームを止める
        Time.timeScale = 0;

        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1);

        countdownText.text = "GO!";

        // ここでゲーム開始
        IsPlaying = true;
        Time.timeScale = 1;

        yield return new WaitForSeconds(0.8f);

        countdownText.gameObject.SetActive(false);

        countdownCoroutine = null;
    }

    public void ShowGameOver()
    {
        // カウントダウンを止める
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }

        // カウントダウンUIを消す
        countdownText.gameObject.SetActive(false);
        tapToStartPanel.SetActive(false);

        // プレイ中ではなくする
        IsPlaying = false;

        // ゲームを止める
        Time.timeScale = 0;

        // ゲームオーバー画面を表示
        gameOverPanel.SetActive(true);
    }

    public void ShowClear()
    {
        // カウントダウンを止める
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }

        countdownText.gameObject.SetActive(false);
        tapToStartPanel.SetActive(false);

        IsPlaying = false;

        Time.timeScale = 0;

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