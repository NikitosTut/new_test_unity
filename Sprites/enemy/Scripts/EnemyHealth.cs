using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject coinPrefab; // ← сюда префаб монеты
    public Sprite deadSprite;
    public SpriteRenderer spriteRenderer; // ← назначь в инспекторе
    private Animator animator;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Отключаем анимацию, чтобы не мешала мёртвому спрайту
        if (animator != null)
            animator.enabled = false;

        // Ставим спрайт мёртвого врага
        if (spriteRenderer != null && deadSprite != null)
            spriteRenderer.sprite = deadSprite;

        // Отключаем поведение
        EnemyShooter shooter = GetComponentInParent<EnemyShooter>();
        if (shooter != null)
            shooter.enabled = false;

        EnemyAI ai = GetComponent<EnemyAI>();
        if (ai != null)
            ai.enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        // Запускаем удаление и выпадение монеты
        StartCoroutine(DropCoinAndDie());
    }

    IEnumerator DropCoinAndDie()
    {
        // Ждём 5 секунд
        yield return new WaitForSeconds(5f);

        // Спавним монету
        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        // Удаляем врага
        Destroy(transform.parent.gameObject);
    }
}
