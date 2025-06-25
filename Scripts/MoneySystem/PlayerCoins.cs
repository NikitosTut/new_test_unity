using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour {
    public int coins = 0;
    public TMP_Text coinText; // Потяни сюда в инспекторе `CoinText`

    void Start()
    {
        if (coinText == null)
        {
            GameObject found = GameObject.FindWithTag("coinText");
            if (found != null)
                coinText = found.GetComponent<TMP_Text>();
        }
        UpdateUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "" + coins.ToString();
    }
}
