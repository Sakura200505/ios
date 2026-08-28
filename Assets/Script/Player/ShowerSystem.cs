using UnityEngine;

public class ShowerSystem : MonoBehaviour
{
    [Header("清潔度回復量")]
    [SerializeField] private float cleanAmount = 20f;

    [Header("経験値")]
    [SerializeField] private int expAmount = 2;

    [Header("シャワーした時のエフェクト")]
    [SerializeField] private ParticleSystem showerEffect;

    [Header("シャワー効果音")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip showerSound;

    public void Shower()
    {
        // 清潔度がmaxならボタンを押しても反応しないようにする
        if (StatusManager.Instance.clean >= StatusManager.Instance.maxClean)
        {
            Debug.Log("もうきれいな状態だよ！");
            return;
        }

        StatusManager.Instance.IncreaseClean(cleanAmount);
        StatusManager.Instance.AddExp(expAmount);

        // エフェクト再生
        showerEffect.Play();

        // 効果音再生
        Debug.Log("シャワー音を再生！");
        audioSource.PlayOneShot(showerSound);

        Debug.Log("シャワーをした！");
    }
}