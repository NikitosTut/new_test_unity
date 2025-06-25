using UnityEngine;

public class CoinPickup : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCoins pc = other.GetComponent<PlayerCoins>();
            if (pc != null)
            {
                pc.AddCoin();
                Destroy(gameObject);
            }
        }
    }
}
