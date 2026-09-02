using UnityEngine;

public class StressSystem : MonoBehaviour
{
    [Header("ペットの不満度")]
    [SerializeField] private float stressDownAmount = 15f;

    [Header("撫でたことによる経験値")]
    [SerializeField] private int expAmount = 1;

    [Header("撫でるエフェクト")]
    [SerializeField] private ParticleSystem petEffect;

    public void Pet()
    {
        bool success = StatusManager.Instance.DecreaseStress(stressDownAmount);

        if (!success)
        {
            Debug.Log("もう満足している！");
            return;
        }

        StatusManager.Instance.AddExp(expAmount);

        //エフェクト再生
        petEffect.Play();

        Debug.Log("撫でた！");
    }
}
