using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MotherPumpkinHP : MonoBehaviour
{
    [SerializeField] private VoidEventSO gameOverEvent;
    public static readonly int maxHealth = 1000;
    public static int currentHealth = 1000;

    private bool gameIsOver = false;
    void Update()
    {
        if (currentHealth <= 0 && !gameIsOver)
        {
            gameOverEvent.RaiseEvent();
            gameIsOver = true;
        }
    }
    public static void LoseHealth(int value)
    {
        currentHealth -= value;
    }
    public void GainHealth(int value)
    {
        currentHealth += value;
    }
}
