using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Game Object event")]
public class TotalListCheckEvent : ScriptableObject
{
    public UnityAction<GameObject, bool> OnEventRaised;

    public void RaiseEvent(GameObject pumpkin, bool getsAdded)
    {
        OnEventRaised?.Invoke(pumpkin, getsAdded);
    }
}
