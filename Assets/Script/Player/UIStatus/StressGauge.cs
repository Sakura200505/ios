using UnityEngine;
using UnityEngine.UI;

public class StressGauge : MonoBehaviour
{
    [SerializeField] private Image stressFill;

    private void Update()
    {
        stressFill.fillAmount = StatusManager.Instance.GetStressNormalized();
    }
}
