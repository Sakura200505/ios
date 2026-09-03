using UnityEngine;

public class ShowerSystem : MonoBehaviour
{
    [Header("清潔度回復量")]
    [SerializeField] private float cleanAmount = 100f;

    [Header("経験値")]
    [SerializeField] private int expAmount = 2;

    [Header("シャワーした時のエフェクト")]
    [SerializeField] private ParticleSystem showerEffect;

    [Header("シャワー効果音")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip showerSound;

    public void Shower()
    {
        // 清潔度がMAXなら何もしない
        if (StatusManager.Instance.clean >= StatusManager.Instance.maxClean)
        {
            Debug.Log("もうきれいな状態だよ！");
            return;
        }

        // 清潔度を回復
        StatusManager.Instance.IncreaseClean(cleanAmount);

        // 経験値を追加
        StatusManager.Instance.AddExp(expAmount);

        // エフェクト再生
        showerEffect.Play();

        // 効果音再生
        audioSource.PlayOneShot(showerSound);

        Debug.Log("シャワーをした！");
    }
}