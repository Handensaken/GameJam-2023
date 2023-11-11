using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Int event")]
public class IntEvent : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void RaiseEvent(int amount)
    {
        OnEventRaised?.Invoke(amount);
    }
}
