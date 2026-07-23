using UnityEngine;
using System;

public class WalkManager : MonoBehaviour
{
    public static WalkManager Instance;

    public bool isWalking = false;
    public DateTime endTime;

    private void Awake()
    {
        Debug.Log($"WalkManager Awake {GetInstanceID()}");

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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

    //散歩開始（ボタンから呼ぶ）
    public void StartWalk()
    {
        Debug.Log("① StartWalk開始");

        // デイリーの散歩回数を追加
        DailyManager.Instance.AddWalk();
        Debug.Log("② AddWalk完了");

        isWalking = true;

        int duration = 10;
        endTime = DateTime.Now.AddSeconds(duration);
        Debug.Log("③ 時間設定完了");

        // 散歩開始状態を保存
        SaveManager.Instance.Save();
        Debug.Log("④ Save完了");

        // 散歩終了通知
        NotificationManager.Instance.ScheduleNotification(
            "散歩終了！",
            "ペットが帰ってきたよ！",
            duration
        );
        Debug.Log("⑤ Notification完了");
    }

    public float GetRemainingTime()
    {
        if (!isWalking)
            return 0f;

        return Mathf.Max(0f, (float)(endTime - DateTime.Now).TotalSeconds);
    }

    //散歩が可能かの判定
    public bool CanWalk()
    {
        return !isWalking && DailyManager.Instance.CanWalk();
    }

    //散歩終了の判定
    void FinishWalk()
    {
        isWalking = false;

        Debug.Log("散歩終了");

        //アイテムを取得
        ItemManager.Instance.GetRandomItem();

        //散歩終了を保存
        SaveManager.Instance.Save();
    }

    //セーブ機能
    public void Save()
    {
        SaveManager.Instance.Save();
    }

    //ロード機能
    void Load()
    {
        var data = SaveManager.Instance.Load();
        if (data == null) return;

        isWalking = data.IsWalking;

        if (isWalking)
        {
            endTime = DateTime.Parse(data.walkEndTime);

            //オフライン状態で終わっているかのチェック
            if (DateTime.Now >= endTime)
            {
                FinishWalk();
            }
            else
            {
                //残り時間で通知を再セット
                TimeSpan remaining = endTime - DateTime.Now;

                NotificationManager.Instance.ScheduleNotification
                    (
                      "散歩終了！",
                      "ペットが帰ってきたよ！",
                      (int)remaining.TotalSeconds
                    );
            }

        }
    }
}
