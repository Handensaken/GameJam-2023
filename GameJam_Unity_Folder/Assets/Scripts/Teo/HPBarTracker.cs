using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarTracker : MonoBehaviour
{
    [SerializeField] private Image hpBarFill;
    
    void Start()
    {
        hpBarFill.fillAmount = MotherPumpkinHP.currentHealth / MotherPumpkinHP.maxHealth;
    }

    void Update()
    {
        hpBarFill.fillAmount = (float)MotherPumpkinHP.currentHealth / (float)MotherPumpkinHP.maxHealth;
        Debug.Log( MotherPumpkinHP.currentHealth / MotherPumpkinHP.maxHealth);
    }
}
