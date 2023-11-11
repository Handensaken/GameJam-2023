using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/New percent event")]
public class SendNewPercentEventSO : ScriptableObject
{
    public UnityAction<int, int, int, int> OnEventRaised;

    public void RaiseEvent(int lv1, int lv2, int lv3, int lv4)
    {
        OnEventRaised?.Invoke(lv1, lv2, lv3, lv4);
    }
}
