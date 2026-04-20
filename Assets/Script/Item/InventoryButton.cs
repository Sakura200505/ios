using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPanel;

    public void ToggleInventory()
    {
        bool isOpen = !InventoryPanel.activeSelf;
        InventoryPanel.SetActive(isOpen);

        if ( isOpen )
        {
            ItemUIManager.Instance.Refresh(Inventory.Instance.items);
        }

        Debug.Log("ƒCƒ“ƒxƒ“ƒgƒŠbutton‚ð‰Ÿ‚µ‚½‚æ");
    }
}
