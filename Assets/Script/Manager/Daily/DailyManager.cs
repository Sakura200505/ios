using UnityEngine;
using System;
using System.Collections;

public class DailyManager : MonoBehaviour
{
    public static DailyManager Instance;

    // デイリーミッション
    [Header("デイリーミッション")]
    public float foodProgress;
    public float showerProgress;
    public float stressProgress;

    // ミッション受け取り
    [Header("ミッション受け取り")]
    public bool foodReceived;
    public bool showerReceived;
    public bool stressReceived;
    public bool walkReceived;

    // 最終報酬
    [Header("最終報酬")]
    public float rewardProgress;
    public bool rewardReceived;


    // 散歩
    [Header("散歩")]
    public int walkCount;

    private const int maxWalkCount = 2;

    // 最後にプレイした日付
    private string lastDate;

    public string LastDailyDate
    {
        get { return lastDate; }
    }

    // Awake
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
            Debug.LogError(
                $"DailyManager重複検知！ Instance:{Instance.GetInstanceID()} New:{GetInstanceID()}"
            );

            Destroy(gameObject);
        }
    }


    // 起動時処理
    private void Start()
    {
        StartCoroutine(InitializeDaily());
    }


    // デイリー初期化
    //
    // ① セーブデータをロード
    // ② DailyManagerへ復元
    // ③ 日付チェック
    // ④ 日付が変わっていたらリセット
    private IEnumerator InitializeDaily()
    {
        // SaveManagerが生成されるまで待つ
        while (SaveManager.Instance == null)
        {
            yield return null;
        }

        // ① セーブデータをロード
        SaveData data = SaveManager.Instance.Load();


    
        // ② デイリーデータを復元
        if (data != null)
        {
            LoadDailyData(data);

            Debug.Log("デイリーデータをロードしました");
        }
        else
        {
            // 初回起動
            ResetDaily();

            lastDate = DateTime.Now.ToString("yyyyMMdd");

            Debug.Log("初回起動なのでデイリーを初期化しました");
        }

        // ③ 日付チェック
        CheckDate();
    }

    // デイリーデータ読み込み
    private void LoadDailyData(SaveData data)
    {
        foodProgress = data.foodProgress;
        showerProgress = data.showerProgress;
        stressProgress = data.stressProgress;

        foodReceived = data.foodReceived;
        showerReceived = data.showerReceived;
        stressReceived = data.stressReceived;
        walkReceived = data.walkReceived;

        rewardProgress = data.rewardProgress;
        rewardReceived = data.rewardReceived;

        walkCount = data.walkCount;

        lastDate = data.lastDailyDate;


        Debug.Log(
            $"デイリーロード：食事={foodProgress} " +
            $"風呂={showerProgress} " +
            $"ストレス={stressProgress} " +
            $"散歩={walkCount}/{maxWalkCount}"
        );
    }

    // 日付チェック
    private void CheckDate()
    {
        string today = DateTime.Now.ToString("yyyyMMdd");

        Debug.Log($"今日の日付：{today}");
        Debug.Log($"保存されている日付：{lastDate}");


        // 日付が変わっている
        if (string.IsNullOrEmpty(lastDate) || lastDate != today)
        {
            Debug.Log("日付が変わったのでデイリーをリセット");


            // ④ デイリーリセット
            ResetDaily();

            // 今日の日付を保存
            lastDate = today;

            // リセット後の状態を保存
            if (SaveManager.Instance != null)
            {
                SaveManager.Instance.Save();
            }
        }
        else
        {
            Debug.Log("日付は変わっていないのでリセットしない");
        }
    }

    // デイリーリセット
    public void ResetDaily()
    {
        Debug.Log("★★★ ResetDaily() 実行 ★★★");


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


    // 食事ミッション達成
    public void CompleteFood()
    {
        foodProgress = 100;

        Debug.Log(
            $"CompleteFood ID:{GetInstanceID()} food={foodProgress}"
        );

        SaveDaily();
    }


    // シャワーミッション達成
    public void CompleteShower()
    {
        showerProgress = 100;

        Debug.Log($"CompleteShower：{showerProgress}");

        SaveDaily();
    }

    // ストレスミッション達成
    public void CompleteStress()
    {
        stressProgress = 100;

        Debug.Log($"CompleteStress：{stressProgress}");

        SaveDaily();
    }

    // 散歩ミッション達成判定
    public bool IsWalkComplete()
    {
        return walkCount >= maxWalkCount;
    }

    // 食事報酬受け取り
    public void ReceiveFood()
    {
        if (foodProgress < 100 || foodReceived)
            return;

        foodReceived = true;

        rewardProgress = Mathf.Clamp(
            rewardProgress + 25,
            0,
            100
        );

        SaveDaily();
    }

    // シャワー報酬受け取り
    public void ReceiveShower()
    {
        if (showerProgress < 100 || showerReceived)
            return;

        showerReceived = true;

        rewardProgress = Mathf.Clamp(
            rewardProgress + 25,
            0,
            100
        );

        SaveDaily();
    }

    // ストレス報酬受け取り
    public void ReceiveStress()
    {
        if (stressProgress < 100 || stressReceived)
            return;

        stressReceived = true;

        rewardProgress = Mathf.Clamp(
            rewardProgress + 25,
            0,
            100
        );

        SaveDaily();
    }

    // 散歩報酬受け取り
    public void ReceiveWalk()
    {
        if (!IsWalkComplete() || walkReceived)
            return;

        walkReceived = true;

        rewardProgress = Mathf.Clamp(
            rewardProgress + 25,
            0,
            100
        );

        SaveDaily();
    }

    // 最終報酬を受け取れるか
    public bool CanReceiveReward()
    {
        return rewardProgress >= 100 && !rewardReceived;
    }

    // 最終報酬
    public void ReceiveReward()
    {
        if (!CanReceiveReward())
            return;

        rewardReceived = true;


        // ゲームチケットを1枚追加
        if (TicketManager.Instance != null)
        {
            TicketManager.Instance.AddTicket(1);
        }


        Debug.Log("ゲームチケットを獲得！");

        SaveDaily();
    }

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

        Debug.Log(
            $"散歩回数：{walkCount}/{maxWalkCount}"
        );

        SaveDaily();

        return true;
    }

    // 残り散歩回数
    public int GetRemainingWalk()
    {
        return maxWalkCount - walkCount;
    }

    // デイリー情報を保存
    private void SaveDaily()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.Save();
        }
    }
}