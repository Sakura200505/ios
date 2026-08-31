using UnityEngine;

public class ButtonSEManager : MonoBehaviour
{
    public static ButtonSEManager Instance;

    [Header("button効果音")]
    [SerializeField] private AudioSource audioSource;

    //通常のボタンの効果音
    [SerializeField] private AudioClip buttonSound;
    //戻るボタンの効果音
    [SerializeField] private AudioClip backSound;

    private void Awake()
    {
        //シングルトンとして管理
       if (Instance == null) 
       {
            Instance = this;
        
       }
       else
       {
            //重複したマネージャーを削除
            Destroy(gameObject);
       }
    }

    //通常のボタンの効果音を再生
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }

    //戻る用のボタンの効果音を再生
    public void PlayBackSound() 
    {
        audioSource.PlayOneShot(backSound);
    }
}
