using UnityEngine;
using System;

public class DailyManager : MonoBehaviour
{
    public static DailyManager Instance;

    [Header("デイリーミッション")]
    public bool loginCompleted;
    public bool foodCompleted;
    public bool showerCompleted;
    public bool stressCompleted;

    [Header("散歩")]
    public int walkCount;
    private const int maxWalkCount = 2;

    private string lastDate;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckDate();
        CompleteLogin();
    }

    // 日付を確認
    void CheckDate()
    {
        string today = DateTime.Now.ToString("yyyyMMdd");
        lastDate = PlayerPrefs.GetString("LastDailyDate", "");

        if (lastDate != today)
        {
            ResetDaily();

            PlayerPrefs.SetString("LastDailyDate", today);
            PlayerPrefs.Save();
        }
    }

    // デイリーミッションをリセット
    void ResetDaily()
    {
        loginCompleted = false;
        foodCompleted = false;
        showerCompleted = false;
        stressCompleted = false;

        walkCount = 0;
    }

    /*=========================
        ミッション達成
    =========================*/

    void CompleteLogin()
    {
        loginCompleted = true;
    }

    public void CompleteFood()
    {
        if (foodCompleted) return;

        foodCompleted = true;
        Debug.Log("ごはんミッション達成！");
    }

    public void CompleteShower()
    {
        if (showerCompleted) return;

        showerCompleted = true;
        Debug.Log("お風呂ミッション達成！");
    }

    public void CompleteStress()
    {
        if (stressCompleted) return;

        stressCompleted = true;
        Debug.Log("ふれあいミッション達成！");
    }

    /*=========================
          散歩関連
    =========================*/

    // 散歩できるか
    public bool CanWalk()
    {
        return walkCount < maxWalkCount;
    }

    // 散歩回数を追加
    public bool AddWalk()
    {
        if (!CanWalk())
            return false;

        walkCount++;

        Debug.Log($"散歩回数：{walkCount}/{maxWalkCount}");

        return true;
    }

    // 残り散歩回数
    public int GetRemainingWalk()
    {
        return maxWalkCount - walkCount;
    }
}