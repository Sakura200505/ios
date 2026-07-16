using UnityEngine;
using System;

public class DailyManager : MonoBehaviour
{
    public static DailyManager instance;

    [Header("デイリーミッション")]
    public bool loginCompleted;
    public bool foodCompleted;
    public bool showerCompleted;
    public bool stressCompleted;
    public int walkCount;

    private string lastDate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

    //この処理はいつなのかを確認する
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

    //この処理はミッションを達成できていないかを確認する
    void ResetDaily()
    {
        loginCompleted = false;
        foodCompleted = false;
        showerCompleted = false;
        stressCompleted = false;
        walkCount = 0;
    }


    //ここからはミッションを達成した時の処理を書く
    void CompleteLogin()
    {
        loginCompleted= true;
    }

    public void CompleteFood()
    {
        if (foodCompleted) return;

        foodCompleted = true;
        Debug.Log("ごはんミッション達成！");
    }

    public void CompleteShower()
    {
        if (showerCompleted) return;

        showerCompleted = true;
        Debug.Log("お風呂ミッション達成！");
    }

    public void CompleteStress()
    {
        if (stressCompleted) return;

        stressCompleted = true;
        Debug.Log("ふれあいミッション達成！");
    }

    public void AddWalk()
    {
        if (walkCount >= 2) return;

        walkCount++;
        Debug.Log($"散歩回数 : {walkCount}/2");
    }
}