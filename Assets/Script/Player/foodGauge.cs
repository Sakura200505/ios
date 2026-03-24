using UnityEngine;
using UnityEngine.UI;
public class foodGauge : MonoBehaviour
{
    [SerializeField] private Image foregroundGauge;
    [SerializeField] private float maxValue = 1f;
    private float current;
    private void Start()
    {
        current = maxValue;
    }
    private void Update()
    {
        // :再生ボタン: 時間で減る（裏ゲージは減らない）
        current -= 1f * Time.deltaTime;
        current = Mathf.Clamp(current, 0f, maxValue);
        foregroundGauge.fillAmount = current / maxValue;
    }
    // :再生ボタン: ボタンで回復
    public void Heal(float amount)
    {
        current += amount;
        current = Mathf.Clamp(current, 0f, maxValue);
    }
}

//using System.Collections;
//using UnityEngine;
//public class GaugeController : MonoBehaviour
//{
//    [SerializeField] private GameObject _gauge;
//    [SerializeField] private GameObject _graceGauge;
//    [SerializeField] private int _HP = 100;
//    private float _HP1;
//    private float _waitingTime = 0.5f;
//    // ▼自動減少のスピード（1秒に何HP減るか）
//    [SerializeField] private float _decreasePerSecond = 1f;
//    void Awake()
//    {
//        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
//    }
//    void Update()
//    {
//        // ▼毎秒HPを減らす
//        AutoDecrease();
//    }
//    // ▼時間経過でゲージ減らす
//    private void AutoDecrease()
//    {
//        float decreaseWidth = _HP1 * _decreasePerSecond * Time.deltaTime;
//        RectTransform gauge = _gauge.GetComponent<RectTransform>();
//        Vector2 now = gauge.sizeDelta;
//        now.x -= decreaseWidth;
//        now.x = Mathf.Max(now.x, 0);  // 0未満にならない
//        gauge.sizeDelta = now;
//        _graceGauge.GetComponent<RectTransform>().sizeDelta = now;
//    }
//    // ▼手動回復（ボタンから呼ぶ）
//    public void Heal(int heal)
//    {
//        float healWidth = _HP1 * heal;
//        RectTransform gaugeRect = _gauge.GetComponent<RectTransform>();
//        Vector2 now = gaugeRect.sizeDelta;
//        float maxWidth = _HP1 * _HP;
//        now.x = Mathf.Min(now.x + healWidth, maxWidth);
//        gaugeRect.sizeDelta = now;
//        _graceGauge.GetComponent<RectTransform>().sizeDelta = now;
//    }
//}