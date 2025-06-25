using UnityEngine;

public class EnemyShooter : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;

    private Transform player;
    private float timer;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        timer = shootInterval;
    }

    void Update()
    {
        if (this == null || firePoint == null || player == null) return;

        float distance = Vector2.Distance(firePoint.position, player.position);

        if (distance <= 5f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                ShootAtPlayer();
                timer = shootInterval;
            }
        }
    }

    void ShootAtPlayer()
    {
        if (firePoint == null || bulletPrefab == null || player == null) return;

        Vector2 direction = (player.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
            bulletScript.SetDirection(direction);
    }
}
