using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 5f;
    public int damage = 10;
    public float lifetime = 5f;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        // ƒополнительно: уничтожать при попадании в стену
        //if (other.CompareTag("Wall") || other.CompareTag("Obstacle"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
