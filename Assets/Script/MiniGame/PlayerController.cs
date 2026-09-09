using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("PlayerにRigidbody2Dが付いていません！");
        }
    }

    void Update()
    {
        if (MiniGameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance が null");
            return;
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D が null");
            return;
        }

        if (MiniGameManager.Instance.isGameOver)
            return;

        // カウントダウン中・ゲーム開始前は操作できない
        if (UIManager.Instance != null && !UIManager.Instance.IsPlaying)
            return;

        // Unity Editorと実機で入力方法を切り替える
        // #if ～ #endif は、ビルドする環境によって使用するコードを切り替えるためのもの
        // Unity Editorではマウスクリック、iPhoneでは画面タップでジャンプする
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#endif
        {
            Debug.Log("Jump!");

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null &&
            collision.rigidbody.CompareTag("Obstacle"))
        {
            MiniGameManager.Instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            MiniGameManager.Instance.GameClear();
        }
    }
}