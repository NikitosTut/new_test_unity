using UnityEngine;

public class Bullet_shotgun : MonoBehaviour {
    public float lifetime = 2f;
    public int damage = 50;
    public GameObject shooter; // <- ����� ��������, ��� ���������

    void Start()
    {
        Destroy(gameObject, lifetime);

        // ���������� ������������ � ���, ��� �������
        if (shooter != null)
        {
            Collider2D shooterCol = shooter.GetComponent<Collider2D>();
            Collider2D bulletCol = GetComponent<Collider2D>();
            if (shooterCol != null && bulletCol != null)
            {
                Physics2D.IgnoreCollision(shooterCol, bulletCol);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // ���������� ������������ � ���, ��� ���������
        if (other.gameObject == shooter) return;

        EnemyHealth enemy = other.collider.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
