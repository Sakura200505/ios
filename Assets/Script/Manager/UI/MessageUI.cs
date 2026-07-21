using UnityEngine;
using TMPro;
using System.Collections;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance;

    [SerializeField] private TextMeshProUGUI messageText;

    private Coroutine currentRoutine;

    private void Awake()
    {
        Instance = this;
        messageText.gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(MessageRoutine(message));
    }

    private IEnumerator MessageRoutine(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        messageText.gameObject.SetActive(false);
    }
}
