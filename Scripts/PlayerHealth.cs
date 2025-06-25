/*using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthBarFill; // сюда потяни HealthBar_Fill

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        float fillAmount = (float)currentHealth / maxHealth;
        healthBarFill.fillAmount = fillAmount;
    }
}*/

using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Image healthBarImage; // ← сюда будем передавать Image из Canvas
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        // Попробуем найти Image с тегом "HealthBar", если он не задан в инспекторе
        if (healthBarImage == null)
        {
            GameObject found = GameObject.FindWithTag("HealthBar");
            if (found != null)
                healthBarImage = found.GetComponent<Image>();
        }

        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBarImage != null)
        {
            float fill = (float)currentHealth / maxHealth;
            healthBarImage.fillAmount = fill;
        }
    }
}
