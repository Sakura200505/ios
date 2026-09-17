using UnityEngine;
using UnityEngine.UI;

public class StatusButtonManager : MonoBehaviour
{
    [Header("ステータスボタン")]
    [SerializeField] private Button foodButton;
    [SerializeField] private Button showerButton;
    [SerializeField] private Button stressButton;

    [Header("ステータスのボタンが押せないときに表示するImage")]
    [SerializeField] private Image foodImage;
    [SerializeField] private Image showerImage;
    [SerializeField] private Image stressImage;

    private void Update()
    {
        if (StatusManager.Instance == null) return;

        // ボタンの有効・無効
        bool canFood = StatusManager.Instance.hunger < StatusManager.Instance.maxHunger - 1f;

        bool canShower = StatusManager.Instance.clean < StatusManager.Instance.maxClean - 1f;

        bool canStress = StatusManager.Instance.stress > 1f;

        foodButton.interactable = canFood;
        showerButton.interactable = canShower;
        stressButton.interactable = canStress;

        // 押せない時だけImageを表示
        foodImage.enabled = !canFood;
        showerImage.enabled = !canShower;
        stressImage.enabled = !canStress;

    }
}