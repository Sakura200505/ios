using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private StrollItemData item;
    private ItemUIManager uiManager;

    public void Setup(StrollItemData item, ItemUIManager manager)
    {
        this.item = item;
        this.uiManager = manager;
        icon.sprite = item.icon;
    }

    public void OnClick()
    {
        uiManager.ShowItemInfo(item);
    }

}
