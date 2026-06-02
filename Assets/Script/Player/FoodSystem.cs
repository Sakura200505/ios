using UnityEngine;

public class FoodSystem : MonoBehaviour
{
    [Header("回復量")]
    [SerializeField] private float hungerAmount = 10f;

    [Header("経験値")]
    [SerializeField] private int expAmount = 4;

    public void food()
    {
        bool success = StatusManager.Instance.IncreaseHunger(hungerAmount);

        //maxならボタンを押しても反応しないように
        if(!success)
        {
            Debug.Log("満腹のため食べられないよ！");
            return;
        }

        //経験値を追加する
        StatusManager.Instance.AddExp(expAmount);

        Debug.Log("ご飯をあげたよ！");
    }
}
