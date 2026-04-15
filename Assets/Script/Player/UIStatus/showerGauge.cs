using UnityEngine;
using UnityEngine.UI;

public class showerGauge : MonoBehaviour
{
    [SerializeField] private Image cleanFill;

    private void Update()
    {
        cleanFill.fillAmount = StatusManager.Instance.GetCleanNormalized();
    }
}
