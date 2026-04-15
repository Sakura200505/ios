using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;

    [Header("満腹度")]
    public float maxHunger = 100f;
    public float hunger = 100f;

    [Header("清潔度")]
    public float maxClean = 100f;
    public float clean = 50f;

    [Header("不満度")]
    public float maxStress = 100f;
    public float stress = 50f;

    [Header("レベル")]
    public int level = 1;
    public int exp;
    public int maxExp = 100;

    private void Awake()
    {
        //Singleton化
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    /*ここからご飯の処理------------------------------------------*/

    //満腹度を減らす
    public void DecreaseHunger(float amount)
    {
        hunger -= amount;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);

        Debug.Log("満腹度：" + hunger);
    }

    //満腹度を回復
    public void IncreaseHunger(float amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);

        Debug.Log("満腹度：" + hunger);
    }

    //UI用処理
    public float GetHungerNormalized()
    {
        return hunger / maxHunger;
    }

    /*ここまでがご飯の処理-----------------------------------------*/



    /*ここからシャワーの処理----------------------------------------*/

    //清潔度を増やす（シャワーボタンを押すことによってゲージを増やす）
    public void IncreaseClean(float amount)
    {
        clean += amount;
        clean = Mathf.Clamp(clean, 0,maxClean);

        Debug.Log("清潔度：" + clean);
    }

    //清潔度を減らす（時間経過によって汚くなる表現を演出）
    public void DecreaseClean(float amount)
    {
        clean -= amount;
        clean = -Mathf.Clamp(clean, 0, maxExp);

        Debug.Log("清潔度：" + clean);
    }

    //UI用処理
    public float GetCleanNormalized()
    {
        return clean / maxClean;
    }

    /*ここまでがシャワーの処理---------------------------------------*/



    /*ここから不満度の処理-------------------------------------------*/

    //放置することによって不満度が増えていく
    public void IncreaseStress(float amount)
    {
        stress += amount;
        stress = Mathf.Clamp(stress, 0, maxStress);

        Debug.Log("不満度：" + stress);
    }

    //撫でることによって不満度が減っていく
    public void DecreaseStress(float amount)
    {
        stress -= amount;
        stress = Mathf.Clamp(stress, 0, maxStress);

        Debug.Log("不満度：" + stress);
    }

    //UI用処理
    public float GetStressNormalized()
    {
        return stress / maxStress;
    }

    /*ここまでが不満度の処理-----------------------------------------*/



    /*ここから経験値の処理-------------------------------------------*/

    //経験値がどれぐらい取得できたか　　
    public void AddExp(int amount)
    {
        exp += amount;
        Debug.Log("経験値：" + exp);

        if (exp >= maxExp)
        {
            LevelUp();
        }
    }

    //ご飯をあげたりシャワーをすることによって獲得できる経験値でレベルをあげていく
    private void LevelUp()
    {
        level++;
        exp = 0;
        Debug.Log("レベルアップ！　Lv." + level);
    }

    /*ここまでが経験値の処理----------------------------------------*/
}
