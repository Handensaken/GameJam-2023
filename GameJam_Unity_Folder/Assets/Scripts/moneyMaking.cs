using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyMaking : MonoBehaviour
{
    public Money playerMoney;
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
        playerMoney.money += moneyPerTick;
    }
}
