using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject textGameObject;
    public Button button;

    private void Start()
    {
        bool isActive = false;  //‚±‚±‚Å”ñ•\Ž¦‚©‚Ç‚¤‚©”»’è‚µ‚Ä‚¢‚é


        button.onClick.AddListener(() =>
        {
            isActive = !isActive;
            textGameObject.SetActive(isActive);
        });
    }
}
