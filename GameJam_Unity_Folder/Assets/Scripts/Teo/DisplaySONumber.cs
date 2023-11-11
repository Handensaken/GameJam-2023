using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySONumber : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;

    
    void Update()
    {
        displayText.text = Money.money.ToString();
    }
}
