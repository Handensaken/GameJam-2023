using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
public class TickHandeler : MonoBehaviour
{
    public static event Action makeMoney;
    public float tickTime = 10;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= tickTime){
            if (makeMoney != null){
                makeMoney();
            }
            currentTime = 0;
        }
    }
    
}
