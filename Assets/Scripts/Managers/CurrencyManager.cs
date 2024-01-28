using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public CurrencyGenerator CurrencyGenerator;

    public List<CurrencyButton> Buttons = new();

    public Action<int> OnUpdateButtonsAction;

    public void OnClickCurrencyButton(int cost)
    {
        CurrencyGenerator.DeductCurrency(cost);
    }
}
