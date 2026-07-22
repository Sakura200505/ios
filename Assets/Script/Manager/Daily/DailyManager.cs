using UnityEngine;
using System;

public class DailyManager : MonoBehaviour
{
    public static DailyManager Instance;

    [Header("デイリーミッション")]
    public bool loginCompleted;

    [Header("報酬")]
    public bool rewardReceived;
    
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
        rewardReceived = false;

        walkCount = 0;
    }


    //ミッション判定処理
    public bool IsFoodComplete()
    {
        return StatusManager.Instance.hunger >= 100;
    }

    public bool IsShowerComplete()
    {
        return StatusManager.Instance.clean >= 100;
    }

    public bool IsStressComplete()
    {
        return StatusManager.Instance.stress <= 0;
    }

    public bool IsWalkComplete()
    {
        return walkCount >= maxWalkCount;
    }
    void CompleteLogin()
    {
        loginCompleted = true;
    }

    //ミッション達成、報酬の処理--------------------------------
    public bool CanReceiveReward()
    {
        return loginCompleted
            && IsFoodComplete()
            && IsShowerComplete()
            && IsStressComplete()
            && IsWalkComplete()
            && !rewardReceived;
    }

    public void ReceiveReward()
    {
        if (!CanReceiveReward())
            return;

        rewardReceived = true;

        Debug.Log("デイリー報酬を受け取りました");
    }

    //散歩関係の処理----------------------------------

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