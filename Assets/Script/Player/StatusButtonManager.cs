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

        float hunger = StatusManager.Instance.hunger;
        float clean = StatusManager.Instance.clean;
        float stress = StatusManager.Instance.stress;

        float maxHunger = StatusManager.Instance.maxHunger;
        float maxClean = StatusManager.Instance.maxClean;

        // ボタンを押せる条件
        bool canFood = hunger < maxHunger - 1f;
        bool canShower = clean < maxClean;
        bool canStress = stress > 1f;

        // Imageの表示条件
        bool showFoodImage = !canFood;
        bool showShowerImage = clean >= maxClean - 1f;
        bool showStressImage = !canStress;

        foodButton.interactable = canFood;
        showerButton.interactable = canShower;
        stressButton.interactable = canStress;

        foodImage.enabled = showFoodImage;
        showerImage.enabled = showShowerImage;
        stressImage.enabled = showStressImage;
    }
}