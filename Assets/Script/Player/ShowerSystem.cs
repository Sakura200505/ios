using UnityEngine;

public class ShowerSystem : MonoBehaviour
{
    [Header("清潔度回復量")]
    [SerializeField] private float cleanAmount = 20f;

    [Header("経験値")]
    [SerializeField] private int expAmount = 2;

    public void Shower()
    {
        StatusManager.Instance.IncreaseClean(cleanAmount);
        StatusManager.Instance.AddExp(expAmount);

        Debug.Log("シャワーをした！");
    }
}
