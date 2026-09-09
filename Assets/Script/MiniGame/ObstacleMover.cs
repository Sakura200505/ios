using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private bool scoreAdded = false;

    [SerializeField] private Transform player;

    void Update()
    {
        if (MiniGameManager.Instance == null)
            return;

        if (MiniGameManager.Instance.isGameOver)
            return;

        // áŠQ•¨‚ªPlayer‚æ‚è¶‚ÉˆÚ“®‚µ‚½‚ç1“_
        if (!scoreAdded && transform.position.x < player.position.x)
        {
            ScoreManager.Instance.AddScore();
            scoreAdded = true;
        }
    }
}