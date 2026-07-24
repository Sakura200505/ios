using UnityEngine;
using System;

public class WalkManager : MonoBehaviour
{
    public static WalkManager Instance;

    [Header("散歩状態")]
    public bool isWalking;
    public DateTime endTime;

    private void Awake()
    {
        Debug.Log($"WalkManager Awake {GetInstanceID()}");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Debug.Log($"WalkManager Start {GetInstanceID()}");
        Load();
    }

    private void Update()
    {
        if (isWalking && DateTime.Now >= endTime)
        {
            FinishWalk();
        }
    }

    //==================================================
    // 散歩開始
    //==================================================
    public void StartWalk()
    {
        Debug.Log("散歩開始");

        if (isWalking)
        {
            Debug.Log("現在散歩中です");
            return;
        }

        if (!DailyManager.Instance.AddWalk())
        {
            Debug.Log("今日はもう散歩できません");
            return;
        }

        isWalking = true;
        endTime = DateTime.Now.AddSeconds(10);   // テスト用

        Save();

        if (NotificationManager.Instance != null)
        {
            NotificationManager.Instance.ScheduleNotification(
                "散歩終了！",
                "ペットが帰ってきたよ！",
                10
            );
        }

        Debug.Log($"散歩開始 残り回数:{DailyManager.Instance.GetRemainingWalk()}");
    }

    //==================================================
    // 散歩終了
    //==================================================
    private void FinishWalk()
    {
        if (!isWalking)
            return;

        isWalking = false;

        Debug.Log("散歩終了");

        if (ItemManager.Instance != null)
        {
            ItemManager.Instance.GetRandomItem();
        }

        Save();
    }

    //==================================================
    // 散歩可能？
    //==================================================
    public bool CanWalk()
    {
        return !isWalking && DailyManager.Instance.CanWalk();
    }

    //==================================================
    // 残り時間
    //==================================================
    public float GetRemainingTime()
    {
        if (!isWalking)
            return 0;

        return Mathf.Max(0, (float)(endTime - DateTime.Now).TotalSeconds);
    }

    //==================================================
    // セーブ
    //==================================================
    public void Save()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.Save();
        }
    }

    //==================================================
    // ロード
    //==================================================
    private void Load()
    {
        if (SaveManager.Instance == null)
            return;

        SaveData data = SaveManager.Instance.Load();

        if (data == null)
            return;

        isWalking = data.IsWalking;

        if (!isWalking)
            return;

        endTime = DateTime.Parse(data.walkEndTime);

        if (DateTime.Now >= endTime)
        {
            FinishWalk();
        }
        else
        {
            int remain = Mathf.CeilToInt((float)(endTime - DateTime.Now).TotalSeconds);

            if (NotificationManager.Instance != null)
            {
                NotificationManager.Instance.ScheduleNotification(
                    "散歩終了！",
                    "ペットが帰ってきたよ！",
                    remain
                );
            }
        }
    }
}