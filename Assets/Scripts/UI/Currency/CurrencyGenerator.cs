using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CurrencyGenerator : MonoBehaviour
{


    public int totalCurrencyCount = 0; // total food currency
    public float currencyGenerationTime = 5f; // Initial time for currency generation
    public float timeRemaining; // Time remaining for the next currency generation

    public Image progressBar; // Reference to the progress bar UI
    public TextMeshProUGUI rateText; // Reference to the rate text UI
    public TextMeshProUGUI currencyCounter; // Reference to the rate text UI

    // Upgrade panel variables
    public GameObject upgradePanel;

    public CurrencyManager currencyManager;
    public float upgradeCost = 10f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        timeRemaining = currencyGenerationTime;
        currencyManager.OnUpdateButtonsAction(totalCurrencyCount);
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        UpdateProgressBar();
        GenerateFood();
    }

    void UpdateProgressBar()
    {
        timeRemaining -= Time.deltaTime;

        progressBar.fillAmount = 1 - (timeRemaining / currencyGenerationTime);
        // rateText.text = (1 / currencyGenerationTime).ToString("F2") + "/s";
    }


    void GenerateFood()
    {
        if (timeRemaining <= 0)
        {
            // Generate food here
            totalCurrencyCount++;
            currencyCounter.text = totalCurrencyCount.ToString();

            currencyManager.OnUpdateButtonsAction(totalCurrencyCount);

            // Reset the timer
            timeRemaining = currencyGenerationTime;
        }
    }


    internal void DeductCurrency(int cost)
    {
        totalCurrencyCount -= cost;
        currencyCounter.text = totalCurrencyCount.ToString();
    }
}
