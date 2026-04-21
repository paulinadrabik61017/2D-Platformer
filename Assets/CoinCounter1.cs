using UnityEngine;
using TMPro;

public class CoinCounter1 : MonoBehaviour
{
    private int currentCoins = 0;
    public TextMeshProUGUI coinText;

    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    public void AddCoin(int amount)
    {
        currentCoins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Monety: " + currentCoins.ToString();
        }
    }
}
