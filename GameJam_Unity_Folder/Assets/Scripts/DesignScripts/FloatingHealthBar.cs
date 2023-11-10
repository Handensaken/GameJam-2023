using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthbar(float CurrentHealth, float MaxHealth)
    {
        slider.value = CurrentHealth / MaxHealth;
    }
}
