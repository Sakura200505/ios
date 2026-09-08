using UnityEngine;

public class WorldMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (MiniGameManager.Instance == null)
            return;

        if (MiniGameManager.Instance.isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = Vector2.left * speed;
    }
}