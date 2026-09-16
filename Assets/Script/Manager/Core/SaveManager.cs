using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    // ステータス
    public float hunger;
    public float clean;
    public float stress;
 
    // レベル
    public int level;
    public int exp;

    // 散歩
    public bool IsWalking;
    public string walkEndTime;

    // セーブ時間
    public string lastSaveTime;

    // デイリーミッション
    public float foodProgress;
    public float showerProgress;
    public float stressProgress;

    // ミッション受け取り
    public bool foodReceived;
    public bool showerReceived;
    public bool stressReceived;
    public bool walkReceived;

    // 最終報酬
    public float rewardProgress;
    public bool rewardReceived;

    // デイリー散歩回数
    public int walkCount;

    // デイリーの日付
    public string lastDailyDate;

    //インベントリ
    public List<string> inventoryItems = new List<string>();
}


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private const string SAVE_KEY = "SAVE_DATA";

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

    // 保存
    public void Save()
    {
        SaveData data = new SaveData();

        // ステータス
        if (StatusManager.Instance != null)
        {
            data.hunger = StatusManager.Instance.hunger;
            data.clean = StatusManager.Instance.clean;
            data.stress = StatusManager.Instance.stress;

            data.level = StatusManager.Instance.level;
            data.exp = StatusManager.Instance.exp;
        }


        // 散歩
        if (WalkManager.Instance != null)
        {
            data.IsWalking = WalkManager.Instance.isWalking;
            data.walkEndTime = WalkManager.Instance.endTime.ToString();
        }



        // デイリー
        if (DailyManager.Instance != null)
        {
            data.foodProgress = DailyManager.Instance.foodProgress;
            data.showerProgress = DailyManager.Instance.showerProgress;
            data.stressProgress = DailyManager.Instance.stressProgress;

            data.foodReceived = DailyManager.Instance.foodReceived;
            data.showerReceived = DailyManager.Instance.showerReceived;
            data.stressReceived = DailyManager.Instance.stressReceived;
            data.walkReceived = DailyManager.Instance.walkReceived;

            data.rewardProgress = DailyManager.Instance.rewardProgress;
            data.rewardReceived = DailyManager.Instance.rewardReceived;

            data.walkCount = DailyManager.Instance.walkCount;

            data.lastDailyDate = DailyManager.Instance.LastDailyDate;
        }

        //インベントリ
        if(Inventory.Instance != null)
        {
            data.inventoryItems.Clear();

            foreach (StrollItemData item in Inventory.Instance.items)
            {
                if(item != null)
                {
                    data.inventoryItems.Add(item.itemName);
                }
            }
        }

        // セーブ時間
        data.lastSaveTime = DateTime.Now.ToString();

        // JSON化
        string json = JsonUtility.ToJson(data);


        // 保存
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();

        Debug.Log("セーブ完了");
    }


    // 読み込み
    public SaveData Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
        {
            Debug.Log("セーブデータなし");
            return null;
        }

        string json = PlayerPrefs.GetString(SAVE_KEY);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        Debug.Log("ロード完了");

        return data;
    }


    // セーブデータ削除
    public void Delete()
    {
        Debug.Log("Delete実行");

        PlayerPrefs.DeleteKey(SAVE_KEY);
        PlayerPrefs.Save();

        //ステータスと経験値を初期化
        if (StatusManager.Instance != null)
        {
            //ご飯・シャワー・触れ合いのゲージを初期値に
            StatusManager.Instance.hunger = 50;
            StatusManager.Instance.clean = 20;
            StatusManager.Instance.stress = 50;
            //経験値の値を初期値に
            StatusManager.Instance.level = 1;
            StatusManager.Instance.exp = 0;
        }

        //デイリー初期化
        if(DailyManager.Instance != null)
        {
            DailyManager.Instance.ResetDaily();
        }

        //インベントリ初期化
        if (Inventory.Instance != null)
        {
            Inventory.Instance.items.Clear();

            if (ItemUIManager.Instance != null)
            {
                ItemUIManager.Instance.Refresh(Inventory.Instance.items);
            }
        }

        Debug.Log("初期化完了");
    }
}