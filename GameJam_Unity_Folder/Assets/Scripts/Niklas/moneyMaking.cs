using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyMaking : MonoBehaviour
{
    public int moneyPerTick = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        TickHandeler.makeMoney += makeMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeMoney(){
        Money.money += moneyPerTick;
    }
}
