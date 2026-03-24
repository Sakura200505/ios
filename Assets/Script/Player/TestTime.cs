using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public DateTime currentTime;
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
        float param = Mathf.Lerp(1.0f, 0.0f, (float)diff.TotalSeconds / 10f);
        m_imgGauge.fillAmount = param;
    }
}
