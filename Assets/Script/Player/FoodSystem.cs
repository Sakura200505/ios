using UnityEngine;

public class FoodSystem : MonoBehaviour
{
    [Header("回復量")]
    [SerializeField] private float hungerAmount = 10f;

    [Header("経験値")]
    [SerializeField] private int expAmount = 2;

    public void food()
    {
        //maxならボタンを押しても反応しないように
        if(StatusManager.Instance.hunger >= StatusManager.Instance.maxHunger)
        {
            Debug.Log("満腹のため食べられないよ！");
            return;
        }

        //満腹度を回復する
        StatusManager.Instance.IncreaseHunger(hungerAmount);

        //経験値を追加する
        StatusManager.Instance.AddExp(expAmount);

        Debug.Log("ご飯をあげたよ！");
    }
}
