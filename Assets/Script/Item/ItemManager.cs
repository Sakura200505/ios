using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public List<StrollItemData> itemList;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    //ランダムにアイテムを取得する
    public void GetRandamItem()
    {
        int index = Random.Range(0, itemList.Count);
        var item = itemList[index];

        Debug.Log("取得：" + item.itemName);

        Inventory.Instance.AddItem(item);
    }
}
