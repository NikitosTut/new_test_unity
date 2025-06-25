using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform firePoint; // ����� �������� (������ �������� �� ���� ���������)
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Передаём Rigidbody2D движение
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed;

        // Указываем, кто выстрелил, чтобы игнорировать игрока
        Bullet_shotgun bulletScript = bullet.GetComponent<Bullet_shotgun>();
        if (bulletScript != null)
        {
            bulletScript.shooter = gameObject; // это Player
        }
    }

}
