using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarTracker : MonoBehaviour
{
    [SerializeField] private Image hpBarFill;
    
    void Start()
    {
        //hpBarFill.fillAmount = hp.currentHealth / hp.maxHealth;
    }

    void Update()
    {
        hpBarFill.fillAmount = MotherPumpkinHP.currentHealth / MotherPumpkinHP.maxHealth;
    }
}
