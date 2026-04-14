using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    [Header("経験値のゲージ")]
    [SerializeField] private Image expFill;

    [Header("経験値のテキスト")]
    [SerializeField] private TextMeshProUGUI levelText;
    //[SerializeField] private TextMeshProUGUI expText;


    private void Update()
    {
        //ゲージ更新
        expFill.fillAmount = (float)StatusManager.Instance.exp / StatusManager.Instance.maxExp;

        //レベル表示
        levelText.text = "Lv." + StatusManager.Instance.level;

        //経験値表示
        //expText.text = StatusManager.Instance.exp + "/" + StatusManager.Instance.maxExp; 
    }
}
