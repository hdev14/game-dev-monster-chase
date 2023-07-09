using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Enemy.TAG))
        {
            Destroy(collision.gameObject);
        }
    }
}
