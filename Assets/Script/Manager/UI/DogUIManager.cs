using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DogSpriteSet
{
    public Sprite normal;
    public Sprite hungry;
    public Sprite dirty;
    public Sprite stress;
}

public class DogUIManager : MonoBehaviour
{
    public Image dogImage;

    [Header("成長段階ごとの表情")]
    public DogSpriteSet[] dogStages;

    //[Header("表情")]
    //public Sprite normalSprite;
    //public Sprite hungrySprite;
    //public Sprite dirtySprite;
    //public Sprite stressSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDogFace();
    }

    //ワンちゃんの表情をここで変更する
    void UpdateDogFace()
    {
        //ステータスマネージャーからワンちゃんの情報を持ってくる
        int stage = StatusManager.Instance.GetDogStage();

        //配列の範囲チェック
        if (stage >= dogStages.Length)
            return;

        DogSpriteSet currentDog = dogStages[stage];

        float hunger = StatusManager.Instance.hunger;　　　//お腹が空いていたら
        float clean = StatusManager.Instance.clean;　　　　//綺麗じゃなかったら
        float stress = StatusManager.Instance.stress;　　　//ストレスが溜まっていたら

        //ゲージが30を切ったらおなかが空いたときの表情に変更
        if (hunger <= 30)
        {
            dogImage.sprite = currentDog.hungry;
        }

        //ゲージが30を切ったら自分が汚くなった時の表情に変更
        else if (clean <= 30)
        {
            dogImage.sprite = currentDog.dirty;
        }

        //ゲージが30を切ったらストレスが溜まって着たときの表情に変更
        else if ( stress >= 30)
        {
            dogImage.sprite= currentDog.stress;  
        }

        //通常の表情
        else
        {
            dogImage.sprite = currentDog.normal;
        }
    }
}

