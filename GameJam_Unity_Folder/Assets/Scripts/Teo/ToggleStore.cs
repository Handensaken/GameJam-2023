using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleStore : MonoBehaviour
{
    [SerializeField] private Vector3 xPosEnter = new Vector3(-125f, 0f, 0f);
    [SerializeField] private Vector3 xPosExit = new Vector3(125f, 0f, 0f);

    [SerializeField] private RectTransform seedStore;
    [SerializeField] private RectTransform arrowButton;

    public void ToggleStoreInOut()
    {
        if (seedStore.anchoredPosition.x < 0f)
        {
            seedStore.anchoredPosition = xPosExit;
            arrowButton.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            seedStore.anchoredPosition = xPosEnter;
            arrowButton.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
