using UnityEngine;

public class HealthTester : MonoBehaviour {
    public PlayerHealth playerHealth;

    void Update()
    {
        // ������� "D", ����� ������� ����
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerHealth.TakeDamage(10);
        }
    }
}