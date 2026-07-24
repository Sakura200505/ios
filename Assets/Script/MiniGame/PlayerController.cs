using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 8f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Player‚ÉRigidbody2D‚ª•t‚¢‚Ä‚¢‚Ü‚¹‚ñI");
        }
    }

    void Update()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance ‚ª null");
            return;
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D ‚ª null");
            return;
        }

        if (GameManager.Instance.isGameOver)
            return;

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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            GameManager.Instance.GameClear();
        }
    }
}