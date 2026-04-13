using UnityEngine;

public class poopGauge : MonoBehaviour
{
    [Header("•óÎ")]
    public int poop = 0;

    public void AddPoop()
    {
        poop++;
    }

    public void ResetPoop()
    {
        poop = 0;
    }
}
