using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend_Pang_DesignEdition : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
            Debug.Log("I've been playing some krunkerrrrrrrrrrrrrrrrrrrrrrr");
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
