using System;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    //Referencja do tekstu
    //Referencja do PlayerHealth
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealChanged += OnHealChanged;
        playerHealth.OnHealthInitialised += OnHealthInit;
    }

    private void OnHealthInit(float newHealth)
    {
       healthText.text = newHealth.ToString();
    }

    public void OnHealChanged(float newHealth, float amountChanged)

    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
    }

    //Kiedy event zostanie wywo³any
    //Zmieniæ napis


}
