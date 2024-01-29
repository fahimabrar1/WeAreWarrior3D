using System;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public CurrencyGenerator CurrencyGenerator;

    [ChildGameObjectsOnly]
    public Transform buttonGroup;

    [AssetSelector(Paths = "Assets/Prefabs/UI")]
    public GameObject buttonPrefab;

    public List<CurrencyButton> Buttons = new();

    public Action<int> OnUpdateButtonsAction;




    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InitiateBattleMode();
    }




    /// <summary>
    /// Deduct the valur from the generator
    /// </summary>
    /// <param name="cost"></param>
    public void OnClickCurrencyButton(int cost)
    {
        CurrencyGenerator.DeductCurrency(cost);
    }



    /// <summary>
    /// 
    /// </summary>
    public void InitiateBattleMode()
    {
        foreach (var soldierData in GameManager.instance.LevelData.levelSoldiersData)
        {
            if (soldierData.isUnlocked)
            {
                var obj = Instantiate(buttonPrefab, buttonGroup);
                if (obj.TryGetComponent(out CurrencyButton button))
                {
                    Buttons.Add(button);
                    button.currencyManager = this;
                    button.SetOnUpdateButtonsAction();
                    button.cost = soldierData.soldierData.SpawnCost;
                    button.character.sprite = soldierData.soldierData.SoldierSprtie;
                    button.soldierType = soldierData.soldierType;
                }
            }
            else
            {
                OnUpdateButtonsAction(CurrencyGenerator.totalCurrencyCount);
                return;
            }
        }
        OnUpdateButtonsAction(CurrencyGenerator.totalCurrencyCount);
    }

}
