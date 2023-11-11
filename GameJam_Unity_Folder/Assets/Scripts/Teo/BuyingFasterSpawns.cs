using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingFasterSpawns : MonoBehaviour
{
    [SerializeField] private VoidEventSO buyThisEvent;
    [SerializeField] private Money playerSeeds;
    [SerializeField] private TMP_Text costDisplayText;
    [SerializeField] private Button buyButton;
    [SerializeField] private List<int> costs = new List<int>();
    private int currentCost = 25;
    private int upgradeStepCounter = 0;
    private bool fullyUpgraded = false;

    private void Awake()
    {
        if (costs.Count > 0)
        {
            currentCost = costs[0];
        }

        costDisplayText.text = currentCost.ToString();
    }

    public void BuyNextUpgrade()
    {
        if (Money.money >= currentCost && !fullyUpgraded)
        {
            Money.money -= currentCost;
            buyThisEvent.RaiseEvent();
            upgradeStepCounter++;

            if (upgradeStepCounter >= costs.Count)
            {
                fullyUpgraded = true;
                buyButton.interactable = false;
                costDisplayText.text = "Fully upgraded!";
            }
            else
            {
                currentCost = costs[upgradeStepCounter];
                costDisplayText.text = currentCost.ToString();
            }
        }
    }
}
