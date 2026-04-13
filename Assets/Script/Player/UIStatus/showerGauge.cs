using UnityEngine;

public class showerGauge : MonoBehaviour
{
    [Header("ê¥åâìx")]
    public float maxClean = 100f;
    public float clean = 100f;

    public void IncreaseClean(float amount)
    {
        clean += amount;
        clean = Mathf.Clamp(clean, 0, maxClean);
    }

    public float GetCleanNormalized()
    {
        return clean / maxClean;
    }
}
