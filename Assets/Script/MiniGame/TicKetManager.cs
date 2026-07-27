using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public static TicketManager Instance;

    [Header("ミニゲームチケット")]
    [SerializeField] private int ticketCount = 0;

    public int TicketCount => ticketCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadTicket();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // チケットを追加
    public void AddTicket(int amount)
    {
        ticketCount += amount;

        SaveTicket();

        Debug.Log($"チケット +{amount}枚 (現在 {ticketCount}枚)");
    }

    // チケットを使用
    public bool UseTicket()
    {
        Debug.Log($"現在のチケット : {ticketCount}");

        if (ticketCount <= 0)
        {
            Debug.Log("チケットがありません");
            return false;
        }

        ticketCount--;

        SaveTicket();

        Debug.Log($"チケットを1枚使用 (残り {ticketCount}枚)");

        return true;
    }

    // 現在の枚数取得
    public int GetTicketCount()
    {
        return ticketCount;
    }

    // 保存
    private void SaveTicket()
    {
        PlayerPrefs.SetInt("MiniGameTicket", ticketCount);
        PlayerPrefs.Save();
    }

    // 読み込み
    private void LoadTicket()
    {
        ticketCount = PlayerPrefs.GetInt("MiniGameTicket", 0);
    }
}