using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MotherPumpkinHP : MonoBehaviour
{
    [SerializeField] private VoidEventSO gameOverEvent;
    public static readonly int maxHealth = 100;
    public static int currentHealth = 100;

    private bool gameIsOver = false;
    void Update()
    {
        if (currentHealth <= 0 && !gameIsOver)
        {
            gameOverEvent.RaiseEvent();
            gameIsOver = true;
        }
        Debug.Log(maxHealth + "maxhelth");
        Debug.Log(currentHealth + "cur");
    }
    public static void LoseHealth(int value)
    {
        currentHealth -= value;
        Debug.Log("is it work?");
    }
    public void GainHealth(int value)
    {
        currentHealth += value;
    }
}
