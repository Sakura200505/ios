//using UnityEngine;
//using System;
//using UnityEditor.Overlays;
//using System.Data;

//[SerializeField]
//public class SaveDate
//{
//    public float hunger;
//    public string lastSaveTime;
//}

//public class SaveManager : MonoBehaviour
//{
//    public static SaveManager instance;

//    private string key = "SAVE_DATA";

//    private void Awake()
//    {
//        if (instance == null) instance = this;
//        else Destroy(gameObject);
//    }

//    public void Save(float hunger, bool isWalking, DateTime walkEndTime)
//    {
//        SaveData data =new SaveData();


//        data.hunger = hunger;
//        data.lastSaveTime = DataSetDateTime.Now.Tostring();

//        data.isWalking = isWalking;
//        data.walkEndTime = walkEndTime.ToString();

//        string json = JsonUtility.ToJson(data);
//        PlayerPrefs.SetString(key, json);
//        PlayerPrefs.Save();
//    }

//    public SaveData Load()
//    {
//        if (!PlayerPrefs.HasKey(key)) return null;

//        string json = PlayerPrefs.GetString(key);
//        return JsonUtility.FromJson<SaveData>(json);
//    }
//}