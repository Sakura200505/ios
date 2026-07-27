using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameUIManager : MonoBehaviour
{
    public static MiniGameUIManager Instance;

    [SerializeField] private GameObject miniGamePanel;
    [SerializeField] private TMP_Text ticketText;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMiniGame()
    {
        ticketText.text = $"{TicketManager.Instance.TicketCount}";
        miniGamePanel.SetActive(true);
    }

    public void CloseMiniGame()
    {
        miniGamePanel.SetActive(false);
    }

    public void StartMiniGame()
    {
        if (!TicketManager.Instance.UseTicket())
        {
            Debug.Log("チケットがありません");
            return;
        }

        ticketText.text = $"{TicketManager.Instance.TicketCount}";

        SceneManager.LoadScene("GameScene1");
    }
}