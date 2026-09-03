using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public List<StrollItemData> itemList;

    [Header("ご飯を食べたときのエフェクト再生")]
    [SerializeField] private ParticleSystem petEffect;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    //ランダムにアイテムを取得する
    public void GetRandomItem()
    {
        int index = Random.Range(0, itemList.Count);
        var item = itemList[index];

        Debug.Log("取得：" + item.itemName);

        Inventory.Instance.AddItem(item);
    }

    //この処理を書くことでfoodSysteを使わなくて済む
    public void UseItem(StrollItemData item)
    {
        switch (item.itemType)
        {
            case StrollItemData.ItemType.Food:

                bool success =
                    StatusManager.Instance.IncreaseHunger(item.foodValue);

                if (!success)
                {
                    Debug.Log("満腹だから食べられない！");
                    return;
                }

                StatusManager.Instance.AddExp(1);

                //ご飯のエフェクト
                petEffect.Play();

                Inventory.Instance.RemoveItem(item);

                break;

            case StrollItemData.ItemType.Shower:

                StatusManager.Instance.IncreaseClean(item.cleanlinessValue);

                Inventory.Instance.RemoveItem(item);

                break;
        }
    }
}
