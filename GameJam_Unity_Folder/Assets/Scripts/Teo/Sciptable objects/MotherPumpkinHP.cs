using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MotherPumpkinHP", menuName = "GameJam_Unity_Folder/MotherPumpkinHP", order = 0)]
public class MotherPumpkinHP : ScriptableObject
{
    [SerializeField] private VoidEventSO gameOverEvent;
    public int maxHealth = 1000;
    public int currentHealth = 1000;

    private bool gameIsOver = false;

    public void LoseHealth(int value)
    {
        currentHealth -= value;

        if (currentHealth <= 0 && !gameIsOver)
        {
            gameOverEvent.RaiseEvent();
            gameIsOver = true;
        }
    }

    public void GainHealth(int value)
    {
        currentHealth += value;
    }
}
