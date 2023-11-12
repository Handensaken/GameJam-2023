using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyBetterPumpkins : MonoBehaviour
{
    //max adding sound effectos brothas
    [SerializeField] private AudioSource source;

    [SerializeField] private SendNewPercentEventSO buyThisPercentEvent;
    [SerializeField] private TMP_Text costDisplayText;
    [SerializeField] private Button buyButton;
    [SerializeField] private List<int> costs = new List<int>();
    [SerializeField] private List<Vector4> odds = new List<Vector4>();
    private int currentCost = 1000;
    private int upgradeStepCounter = 0;
    private int oddsStepCounter = 0;
    private Vector4 currentOdds = new Vector4(100, 0, 0, 0);
    private bool fullyUpgraded = false;

    private void Awake()
    {
        if (costs.Count > 0)
        {
            currentCost = costs[0];
        }

        if (odds.Count > 0)
        {
            currentOdds = odds[0];
        }

        costDisplayText.text = currentCost.ToString();
    }

    public void BuyNextUpgrade()
    {
        if (Money.money >= currentCost && !fullyUpgraded)
        {
            Money.money -= currentCost;
            buyThisPercentEvent.RaiseEvent((int)currentOdds.x, (int)currentOdds.y, (int)currentOdds.z, (int)currentOdds.w);
            currentOdds = NextOdds();
            upgradeStepCounter++;

            //playing sound
            source.Play();

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

    private Vector4 NextOdds()
    {
        oddsStepCounter++;

        if (oddsStepCounter >= odds.Count)
        {
            return new Vector4(0, 0, 0, 0);
        }
        else
        {
            return odds[oddsStepCounter];
        }
    }
}
