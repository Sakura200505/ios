//using UnityEngine;
//using System.Collections.Generic;
//using NUnit.Framework;

//[CreateAssetMenu(fileName = "ItemDataList", menuName = "ScriptableObjects/ItemDataList")]
//public class ItemDataList : ScriptableObject
//{
//    public List star1Cards;
//    public List star2Cards;
//    public List star3Cards;

//    // 抽選ロジック
//    public ItemData GetRandomItem()
//    {
//        float rand = Random.value;
//        if (rand < 0.6f)
//            return GetRandomFromList(star1Cards);
//        else if (rand < 0.9f)
//            return GetRandomFromList(star2Cards);
//        else
//            return GetRandomFromList(star3Cards);
//    }

//    private ItemData GetRandomFromList(List list)
//    {
//        if (list.Count == 0) return null;
//        return list[Random.Range(0, list.Count)];
//    }
//}