using UnityEngine;
using System;
using UnityEditor.Overlays;
using System.Data;

[System.Serializable]
public class SaveData
{
    //ステータス
    public float hunger;
    public float clean;
    public float stress;

    //レベル
    public int level;
    public int exp;

    //散歩
    public bool IsWalking;
    public string walkEndTime;
    public string lastWalkTime;

    //セーブ時間
    public string lastSaveTime;
}


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string key = "SAVE_DATA";

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

    //保存処理
    public void Save()
    {
        SaveData data = new SaveData();

        //ステータス
        data.hunger = StatusManager.Instance.hunger;
        data.clean = StatusManager.Instance.clean;
        data.stress = StatusManager.Instance.stress;

        data.level = StatusManager.Instance.level;
        data.exp = StatusManager.Instance.exp;
        

        //散歩
        data.IsWalking = WalkManager.Instance.isWalking;
        data.walkEndTime = WalkManager.Instance.endTime.ToString();
        data.lastWalkTime = WalkManager.Instance.lastWalkTime.ToString();

        data.lastSaveTime = DateTime.Now.ToString();

        //Json化
        string json = JsonUtility.ToJson(data);

        //保存
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();

       // Debug.Log("セーブ完了");
    }

    //読み込み処理
    public SaveData Load()
    {
        if (!PlayerPrefs.HasKey(key))
        {
            Debug.Log("セーブデータなし");
            return null;
        }

        //読み込み
        string json = PlayerPrefs.GetString(key);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        Debug.Log("ロード完了");
        return data;
    }

    //データ削除（デバッグ用）
    public void Delete()
    {
        Debug.Log("Delete実行");

        PlayerPrefs.DeleteKey(key);
        PlayerPrefs.Save();

        //
        StatusManager.Instance.hunger = 100;
        StatusManager.Instance.clean = 100;
        StatusManager.Instance.stress = 100;

        //
        StatusManager.Instance.level = 1;
        StatusManager.Instance.exp = 0;

        Debug.Log("セーブ削除");
    }
}