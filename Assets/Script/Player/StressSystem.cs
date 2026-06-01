using UnityEngine;

public class StressSystem : MonoBehaviour
{
    [Header("ペットの不満度")]
    [SerializeField] private float stressDownAmount = 15f;

    [Header("撫でたことによる経験値")]
    [SerializeField] private int expAmount = 3;

    public void Pet()
    {
        StatusManager.Instance.DecreaseStress(stressDownAmount);
        StatusManager.Instance.AddExp(expAmount);

        Debug.Log("撫でた！");
    }
}
