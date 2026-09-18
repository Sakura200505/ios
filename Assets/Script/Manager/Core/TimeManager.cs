using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public DateTime currentTime;

    private void Start()
    {
        currentTime = DateTime.Now;
    }

    // アプリを一時停止したとき
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveGame();
        }
    }

    // アプリを終了したとき
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    // アプリに戻ってきたとき
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (NotificationManager.Instance != null)
            {
                NotificationManager.Instance.ClearAll();
            }
        }
    }

    // ゲームの保存処理
    private void SaveGame()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.Save();
        }

        if (WalkManager.Instance != null)
        {
            WalkManager.Instance.Save();
        }
    }
}