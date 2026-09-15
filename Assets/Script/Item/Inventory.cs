using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<StrollItemData> items =
        new List<StrollItemData>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // アイテム追加
    public void AddItem(StrollItemData item)
    {
        if (item == null)
            return;


        items.Add(item);


        // UI更新
        if (ItemUIManager.Instance != null)
        {
            ItemUIManager.Instance.Refresh(items);
        }


        // 保存
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.Save();
        }
    }

    // アイテム削除
    public void RemoveItem(StrollItemData item)
    {
        if (item == null)
            return;


        items.Remove(item);


        // UI更新
        if (ItemUIManager.Instance != null)
        {
            ItemUIManager.Instance.Refresh(items);
        }


        // 保存
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.Save();
        }
    }

    // インベントリ読み込み
    public void LoadInventory(SaveData data)
    {
        if (data == null)
            return;


        items.Clear();


        if (data.inventoryItems == null)
            return;


        // ItemManagerのアイテム一覧から
        // 保存されているアイテムを探す
        foreach (string itemName in data.inventoryItems)
        {
            StrollItemData item =
                FindItemByName(itemName);


            if (item != null)
            {
                items.Add(item);
            }
            else
            {
                Debug.LogWarning(
                    $"アイテムが見つかりません：{itemName}"
                );
            }
        }


        // UI更新
        if (ItemUIManager.Instance != null)
        {
            ItemUIManager.Instance.Refresh(items);
        }


        Debug.Log(
            $"インベントリロード完了：{items.Count}個"
        );
    }

    // アイテム検索
    private StrollItemData FindItemByName(
        string itemName)
    {
        if (ItemManager.Instance == null)
            return null;


        foreach (
            StrollItemData item
            in ItemManager.Instance.itemList)
        {
            if (item != null &&
                item.itemName == itemName)
            {
                return item;
            }
        }


        return null;
    }
}