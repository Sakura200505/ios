using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ItemUIManager : MonoBehaviour
{
    public static ItemUIManager Instance;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("詳細UI")]
    [SerializeField] private Image datailIcon;
    [SerializeField] private Text detailName;
    [SerializeField] private Text detailDescription;

    private void Awake()
    {
        Instance = this;
    }


    public void Refresh(List<StrollItemData> items)
    {
        //全削除
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        //所為アイテムだけを生成する
        foreach (var item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            var slotScript = slot.GetComponent<ItemSlot>();
            slotScript.Setup(item, this);
        }
    }


    public void ShowItemInfo(StrollItemData item)
    {
        datailIcon.sprite = item.icon;
        detailName.text = item.itemName;
        detailDescription.text = item.description;
    }
}
