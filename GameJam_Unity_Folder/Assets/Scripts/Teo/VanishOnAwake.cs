using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishOnAwake : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();

        sr.color = new Color(0, 0, 0, 0);
    }
}
