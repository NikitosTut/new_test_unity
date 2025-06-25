using UnityEngine;

public class HealthTester : MonoBehaviour {
    public PlayerHealth playerHealth;

    void Update()
    {
        // Нажмите "D", чтобы нанести урон
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerHealth.TakeDamage(10);
        }
    }
}