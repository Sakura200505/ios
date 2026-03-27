//using UnityEngine;
//using System;
//using UnityEditor.Overlays;
//using System.Data;

//[SerializeField]
//public class SaveDate
//{
//    public float hunger;
//    public string lastSaveTime;
//    public bool isWalking;
//    public string walkEndTime;
//    public string lastWalkTime;
//}

//public class SaveManager : MonoBehaviour
//{
//    public static SaveManager Instance;

//    private string key = "SAVE_DATA";

//    private void Awake()
//    {
//        if (Instance == null) Instance = this;
//        else Destroy(gameObject);
//    }

//    //保存処理
//    public void Save(float hunger, bool isWalking, DateTime walkEndTime, DateTime lastWalkTime)
//    {
//        SaveDate data = new SaveDate();


//        data.hunger = hunger;
//        data.lastSaveTime = DataSetDateTime.Now.Tostring();

//        data.isWalking = isWalking;
//        data.walkEndTime = walkEndTime.ToString();
//        data.lastWalkTime = lastWalkTime.ToString();

//        string json = JsonUtility.ToJson(data);
//        PlayerPrefs.SetString(key, json);
//        PlayerPrefs.Save();

//        Debug.Log("セーブ完了");
//    }

//    //読み込み処理
//    public SaveDate Load()
//    {
//        if (!PlayerPrefs.HasKey(key)) return null;
//        {
//            Debug.Log("セーブデータなし");
//            return null;
//        }

//        string json = PlayerPrefs.GetString(key);
//        SaveDate data = JsonUtility.FromJson<SaveDate>(json);

//        Debug.Log("ロード完了");
//        return data;
//    }

//    //データ削除（デバッグ用）
//    public void Delete()
//    {
//        PlayerPrefs.DeleteKey(key);
//        Debug.Log("セーブ削除");
//    }
//}