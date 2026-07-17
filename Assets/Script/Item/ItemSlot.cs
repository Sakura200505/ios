using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button button;   //追加

    private StrollItemData item;
    private ItemUIManager uiManager;

    public void Setup(StrollItemData item, ItemUIManager manager)
    {
        this.item = item;
        this.uiManager = manager;

        icon.sprite = item.icon;

        // ボタンイベントをコードで登録
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log(item.itemName + "を押した！");
        uiManager.ShowItemInfo(item);
    }
}