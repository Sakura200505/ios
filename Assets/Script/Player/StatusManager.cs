using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;

    [Header("ステータス")]
    public float maxHunger = 100f;
    public float hunger = 100f;
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

    //UI用（０～１に変化）
    public float GetHungerNormalized()
    {
        return hunger / maxHunger;
    }

    public void AddExp(int amount)
    {
        exp += amount;
        Debug.Log("経験値：" + exp);

        if (exp >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        exp = 0;
        Debug.Log("レベルアップ！　Lv." + level);
    }
}
