
using UnityEngine;
using System.Collections.Generic;

public class DressUpManager : MonoBehaviour
{
    public static DressUpManager Instance;

    [Header("着せ替えアイテム一覧")]
    public List<DressUpItemData> allItems = new List<DressUpItemData>();

    [Header("所持しているアイテムID")]
    public List<string> ownedItemIds = new List<string>();

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

    private void Start()
    {
        LoadOwnedItems();
    }

    // セーブデータから所持アイテムを読み込む
    private void LoadOwnedItems()
    {
        // SaveManagerが存在するか確認
        if (SaveManager.Instance == null)
            return;

        // セーブデータを読み込む
        SaveData data = SaveManager.Instance.Load();

        // セーブデータがない場合
        if (data == null)
            return;

        // 着せ替えアイテムの所持情報を取得
        if (data.ownedDressUpItemIds != null)
        {
            ownedItemIds = new List<string>(data.ownedDressUpItemIds);
        }

        Debug.Log("着せ替えアイテムをロードしました");
    }
}
