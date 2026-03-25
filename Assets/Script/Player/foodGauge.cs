using UnityEngine;
using UnityEngine.UI;

public class foodGauge : MonoBehaviour
{
    [SerializeField] private Image foregroundGauge;

    private void Update()
    {
        //ステータスから値を取得して表示
        foregroundGauge.fillAmount = StatusManager.Instance.GetHungerNormalized();
    }
}