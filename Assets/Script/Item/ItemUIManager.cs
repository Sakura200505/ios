using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ItemUIManager : MonoBehaviour
{
    public static ItemUIManager Instance;
    private StrollItemData currentItem;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("インベントリUI")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("詳細UI")]
    [SerializeField] private Image datailIcon;
    [SerializeField] private TMP_Text detailName;
    [SerializeField] private TMP_Text detailDescription;
    [SerializeField] private GameObject detailPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void Refresh(List<StrollItemData> items)
    {
        // 全削除
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        // 所持アイテム生成
        foreach (var item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            var slotScript = slot.GetComponent<ItemSlot>();
            slotScript.Setup(item, this);
        }
    }

    public void ShowItemInfo(StrollItemData item)
    {
        currentItem = item;

        detailPanel.SetActive(true);

        datailIcon.sprite = item.icon;
        detailName.text = item.itemName;
        detailDescription.text = item.description;
    }

    public void UseSelectedItem()
    {
        if (currentItem == null)
            return;

        ItemManager.Instance.UseItem(currentItem);

        detailPanel.SetActive(false);
    }

    // インベントリを閉じる
    public void CloseInventory()
    {
        detailPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }
}