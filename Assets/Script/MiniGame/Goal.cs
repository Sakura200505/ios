using UnityEngine;

public class Goal : MonoBehaviour
{
    public float speed = 3;

    void Update()
    {
        if (MiniGameManager.Instance.isGameOver)
            return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}