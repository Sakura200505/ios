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

        //UIçXêV
        ItemUIManager.Instance.Refresh(items);
    }
}