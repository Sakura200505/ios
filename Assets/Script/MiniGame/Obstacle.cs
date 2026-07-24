using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}