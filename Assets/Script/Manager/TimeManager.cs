using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public DateTime currentTime;
    //10秒ごと
    public float interval = 10f;
    public Image m_imgGauge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan diff = DateTime.Now - currentTime;

        if (diff.TotalSeconds >= interval)
        {
            currentTime = DateTime.Now;

            //ここでステータス減少
            StatusManager.Instance.DecreaseHunger(5);
        }

        float param = Mathf.Lerp(1.0f, 0.0f, (float)diff.TotalSeconds / 10f);
        m_imgGauge.fillAmount = param;
    }
}
