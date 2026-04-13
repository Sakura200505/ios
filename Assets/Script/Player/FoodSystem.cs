using UnityEngine;

public class FoodSystem : MonoBehaviour
{
    [Header("回復量")]
    [SerializeField] private float hungerAmount = 10f;

    [Header("経験値")]
    [SerializeField] private int expAmount = 2;

    public void feed()
    {
        //満腹度を回復する
        StatusManager.Instance.IncreaseHunger(hungerAmount);

        //経験値を追加する
        StatusManager.Instance.AddExp(expAmount);

        Debug.Log("ご飯をあげたよ！");
    }
}
