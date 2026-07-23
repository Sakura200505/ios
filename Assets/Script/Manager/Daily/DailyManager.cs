using UnityEngine;
using System;

public class DailyManager : MonoBehaviour
{
    public static DailyManager Instance;

    [Header("デイリーミッション")]
    public float foodProgress;
    public float showerProgress;
    public float stressProgress;

    [Header("報酬")]
    public bool rewardReceived;
    
    [Header("散歩")]
    public int walkCount;
    private const int maxWalkCount = 2;

    private string lastDate;

    private void Awake()
    {
        Debug.Log($"DailyManager Awake  ID:{GetInstanceID()}");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError($"重複検知！ Instance:{Instance.GetInstanceID()}  New:{GetInstanceID()}");
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CheckDate();
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

    void ResetDaily()
    {
        foodProgress = 0;
        showerProgress = 0;
        stressProgress = 0;

        rewardReceived = false;
        walkCount = 0;
    }


    //ミッション判定処理
    private void Update()
    {
        CheckMission();
    }

    void CheckMission()
    {
        if (StatusManager.Instance.hunger >= 100)
            foodProgress = 100;

        if (StatusManager.Instance.clean >= 100)
            showerProgress = 100;

        if (StatusManager.Instance.stress <= 0)
            stressProgress = 100;
    }

    public bool IsWalkComplete()
    {
        return walkCount >= maxWalkCount;
    }

    //ミッション達成、報酬の処理--------------------------------
    public bool CanReceiveReward()
    {
        return foodProgress >= 100
            && showerProgress >= 100
            && stressProgress >= 100
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

    private void OnDestroy()
    {
        Debug.Log($"DailyManager Destroy ID:{GetInstanceID()}");
    }
}