using UnityEngine;
using System;

public class DailyManager : MonoBehaviour
{
    public static DailyManager Instance;

    [Header("デイリーミッション")]
    public float foodProgress;
    public float showerProgress;
    public float stressProgress;

    [Header("ミッション受け取り")]
    public bool foodReceived;
    public bool showerReceived;
    public bool stressReceived;
    public bool walkReceived;

    [Header("最終報酬")]
    public float rewardProgress;
    public bool rewardReceived;

    [Header("散歩")]
    public int walkCount;
    private const int maxWalkCount = 2;

    private string lastDate;

    private void Awake()
    {
        Debug.Log($"DailyManager Awake ID:{GetInstanceID()}");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError($"重複検知！ Instance:{Instance.GetInstanceID()} New:{GetInstanceID()}");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckDate();
    }

    // 日付変更
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

    void ResetDaily()
    {
        // ミッション進捗
        foodProgress = 0;
        showerProgress = 0;
        stressProgress = 0;

        // 散歩
        walkCount = 0;

        // ミッション受け取り
        foodReceived = false;
        showerReceived = false;
        stressReceived = false;
        walkReceived = false;

        // 最終報酬
        rewardProgress = 0;
        rewardReceived = false;
    }

    // ミッション達成

    public void CompleteFood()
    {
        foodProgress = 100;

        Debug.Log($"CompleteFood ID:{GetInstanceID()} food={foodProgress}");
    }

    public void CompleteShower()
    {
        showerProgress = 100;
    }

    public void CompleteStress()
    {
        stressProgress = 100;
    }

    public bool IsWalkComplete()
    {
        return walkCount >= maxWalkCount;
    }

    // ミッション受け取り
    public void ReceiveFood()
    {
        if (foodProgress < 100 || foodReceived)
            return;

        foodReceived = true;
        rewardProgress = Mathf.Clamp(rewardProgress + 25, 0, 100);
    }

    public void ReceiveShower()
    {
        if (showerProgress < 100 || showerReceived)
            return;

        showerReceived = true;
        rewardProgress = Mathf.Clamp(rewardProgress + 25, 0, 100);
    }

    public void ReceiveStress()
    {
        if (stressProgress < 100 || stressReceived)
            return;

        stressReceived = true;
        rewardProgress = Mathf.Clamp(rewardProgress + 25, 0, 100);
    }

    public void ReceiveWalk()
    {
        if (!IsWalkComplete() || walkReceived)
            return;

        walkReceived = true;
        rewardProgress = Mathf.Clamp(rewardProgress + 25, 0, 100);
    }

    // 最終報酬
    public bool CanReceiveReward()
    {
        return rewardProgress >= 100 && !rewardReceived;
    }

    public void ReceiveReward()
    {
        if (!CanReceiveReward())
            return;

        rewardReceived = true;

        // TODO: ゲームチケット追加
        Debug.Log("ゲームチケットを獲得！");
    }

    // 散歩
    public bool CanWalk()
    {
        return walkCount < maxWalkCount;
    }

    public bool AddWalk()
    {
        if (!CanWalk())
            return false;

        walkCount++;

        Debug.Log($"散歩回数：{walkCount}/{maxWalkCount}");

        return true;
    }

    public int GetRemainingWalk()
    {
        return maxWalkCount - walkCount;
    }
}