using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrencyButton : MonoBehaviour
{

    public bool canBuy;
    public int cost;
    public TextMeshProUGUI costText;
    public Button button;
    public CurrencyManager currencyManager;


    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        currencyManager.OnUpdateButtonsAction += OnUpdateButtons;
    }


    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        currencyManager.OnUpdateButtonsAction -= OnUpdateButtons;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        canBuy = false;
        costText.text = cost.ToString();
    }




    private void OnUpdateButtons(int currencyValue)
    {
        if (currencyValue >= cost)
        {

            button.interactable = true;
            //Todo: make is purchasable
        }
        else
        {
            button.interactable = false;
        }
    }



    public void OnClickButton()
    {
        currencyManager.OnClickCurrencyButton(cost);
        GameManager.instance.battleManager.playerbase.SpawnSoldier();
    }
}