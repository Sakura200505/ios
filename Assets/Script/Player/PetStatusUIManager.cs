using UnityEngine;

public class PetStatusUIManager : MonoBehaviour
{
    [SerializeField] private GameObject statusPanel;

    // ペットを押したら開閉
    public void ToggleStatus()
    {
        bool isOpen = !statusPanel.activeSelf;
        statusPanel.SetActive(isOpen);

        Debug.Log("ペットを押したよ！");
    }

    // 閉じるボタン用
    public void CloseStatus()
    {
        statusPanel.SetActive(false);
    }
}