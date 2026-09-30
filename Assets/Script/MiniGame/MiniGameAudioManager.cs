using UnityEngine;

public class MiniGameAudioManager : MonoBehaviour
{
    public static MiniGameAudioManager Instance;

    [Header("音を再生するAudioSource")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    [Header("BGM")]
    [SerializeField] private AudioClip bgm;

    [Header("効果音")]
    [SerializeField] private AudioClip jumpSE;
    [SerializeField] private AudioClip hitSE;
    [SerializeField] private AudioClip gameOverSE;
    [SerializeField] private AudioClip clearSE;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayBGM();
    }

    //BGM再生
    public void PlayBGM()
    {
        if (bgmSource == null || bgm == null) return;

        bgmSource.clip = bgm;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    //BGMを停止させる
    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }

    //ジャンプ音再生
    public void PlayJumpSE()
    {
        PlaySE(jumpSE);
    }

    //障害物にぶつかった音
    public void PlayHitSE()
    {
        PlaySE(hitSE);
    }

    //ゲームオーバー
    public void PlayGameOverSE()
    {
        PlaySE(gameOverSE);
    }

    //ゲームクリア音
    public void PlayGameClearSE()
    {
        PlaySE(clearSE);
    
    }

    //効果音を再生する共通処理
    private void PlaySE(AudioClip clip)
    {
        if (seSource == null || clip == null) return;

        seSource.PlayOneShot(clip);
    }
    
}
