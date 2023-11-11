using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySONumber : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Money moneyContainer;

    
    void Update()
    {
        displayText.text = moneyContainer.money.ToString();
    }
}
