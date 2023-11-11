using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyGoodcrows : MonoBehaviour
{
    //[SerializeField] private VoidEventSO buyThisEvent;
    [SerializeField] private Money playerSeeds;
    [SerializeField] private TMP_Text costDisplayText;
    [SerializeField] private Button buyButton;
    [SerializeField] private List<int> costs = new List<int>();
    [SerializeField] private List<GameObject> goodCrows = new List<GameObject>();
    private int currentCost = 10;
    private int upgradeStepCounter = 0;
    private bool fullyUpgraded = false;

    private void Awake()
    {
        if (costs.Count > 0)
        {
            currentCost = costs[0];
        }

        costDisplayText.text = currentCost.ToString();

        foreach (GameObject goodCrow in goodCrows)
        {
            goodCrow.SetActive(false);
        }
    }

    public void BuyNextUpgrade()
    {
        if (playerSeeds.money >= currentCost && !fullyUpgraded)
        {
            playerSeeds.money -= currentCost;
            //buyThisEvent.RaiseEvent();
            ActivateNextGoodcrow();
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

    private void ActivateNextGoodcrow()
    {
        if (goodCrows.Count > 0)
        {
            goodCrows[0].SetActive(true);
            goodCrows.RemoveAt(0);
        }
    }
}
