//using UnityEngine;
//using Unity.Notifications.iOS;
//using System;
//using System.Net;
//using UnityEditor;
//using UnityEngine.UIElements;

//public class NotificationManager : MonoBehaviour
//{
//    public static NotificationManager Instance;

//    private void Awake()
//    {
//        if (Instance == null) Instance = this;
//        else Destroy(gameObject);
//    }

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        RequestPermission();
//    }

//    //通知許可の表示（初回）
//    private void RequestPermission()
//    {
//        var request = new AuthorizationRequest
//            (
//                AuthorizationOption.Alert | AuthorizationOption.Badge,true
//            );
//    }

//    //通知をスケジュール
//    public void ScheduleNotification(string title, string body, int seconds)
//    {
//        if (seconds <= 0) return;

//        var trigger = new iOSNotificationTimeIntervalTrigger()
//        {
//            TimeInterval = TimeSpan.FromSeconds(seconds),
//            Repeat = false
//        };
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
