//using UnityEngine;
//using System;

//public class WalkManager : MonoBehaviour
//{
//    public static WalkManager Instance;

//    public bool isWalking = false;
//    public DateTime endTime;

//    //クールタイム管理
//    public DateTime lastWalkTime;
//    public float walkCooldownSeconds = 3600f;  //散歩のクールタイム

//    private void Awake()
//    {
//        if (Instance == null) Instance = this;
//        else Destroy(gameObject);
//    }

//    private void Start()
//    {
//        Load();
//    }

//    private void Update()
//    {
//        if (isWalking && DateTime.Now >= endTime)
//        {
//            FinishWalk();
//        }
//    }

//    //散歩開始（ボタンから呼ぶ）
//    public void StartWalk()
//    {
//        if (!CanWalk()) return;

//        isWalking = true;
//        lastWalkTime = DateTime.Now;

//        int duration = 10; //散歩の時間指定１０秒（何時間か掛けるようにするか検討）
//        endTime = DateTime.Now.AddSeconds(duration);

//        //散歩が終わった後の通知
//        NotificationManager.Instance.ScheduleNotification
//            ("散歩終了！", "ペットが帰ってきたよ！", duration);
//    }

//    //散歩が可能かの判定
//    public bool CanWalk()
//    {
//        TimeSpan diff = DateTime.Now - lastWalkTime;
//        return diff.TotalSeconds >= walkCooldownSeconds && !isWalking;
//    }

//    //散歩終了の判定
//    void FinishWalk()
//    {
//        isWalking = false;

//        Debug.Log("散歩終了");

//        //アイテムを取得
//        ItemManager.Instance.GetRandomItem();
//    }

//    //残り時間のクールタイム
//    public float GetRemainingCooldown()
//    {
//        float remain = walkCooldownSeconds - (float)(DateTime.Now - lastWalkTime).TotalSeconds;
//        return Mathf.Max(0, remain);
//    }

//    //セーブ機能
//    public void Save()
//    {
//        SaveManager.Instance.Save
//            (
//                 StatusManager.Instance.hunger,
//                 isWalking,
//                 endTime,
//                 lastWalkTime
//            );
//    }

//    //ロード機能
//    void Load()
//    {
//        var data = SaveManager.Instance.Load();
//        if (data == null) return;

//        isWalking = data.IsWalking;

//        if (isWalking)
//        {
//            endTime = DateTime.Parse(data.walkEndTime);

//            //オフライン状態で終わっているかのチェック
//            if (DateTime.Now >= endTime)
//            {
//                FinishWalk();
//            }
//            else
//            {
//                //残り時間で通知を再セット
//                TimeSpan remaining = endTime - DateTime.Now;

//                NotificationManager.Instance.ScheduleNotification
//                    (
//                      "散歩終了！",
//                      "ペットが帰ってきたよ！",
//                      (int)remaining.TotalSeconds
//                    );
//            }

//        }
//    }
//}
