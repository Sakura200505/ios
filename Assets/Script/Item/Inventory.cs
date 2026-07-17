using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<StrollItemData> items = new List<StrollItemData>();

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

    public void AddItem(StrollItemData item)
    {
        items.Add(item);

        //UI更新
        ItemUIManager.Instance.Refresh(items);
    }

    public void RemoveItem(StrollItemData item) 
    {
        items.Remove(item);

        //UI更新
        ItemUIManager.Instance.Refresh(items);
    }
}