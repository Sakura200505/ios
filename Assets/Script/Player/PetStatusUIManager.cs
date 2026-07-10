using UnityEngine;

public class PetStatusUIManager : MonoBehaviour
{
    [SerializeField] private GameObject statusPanel;

    public void ToggleStatus()
    {
        bool isOpen = !statusPanel.activeSelf;
        statusPanel.SetActive(isOpen);

        Debug.Log("ペットを押したよ！");
    }

}
