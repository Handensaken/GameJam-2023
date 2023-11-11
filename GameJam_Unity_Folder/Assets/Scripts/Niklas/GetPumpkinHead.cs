using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPumpkinHead : MonoBehaviour
{
    [NonSerialized]
    public bool used = false;
    public void getLevel(int lvl)
    {
        FriendScarecrow friendScarecrow = GetComponent<FriendScarecrow>();
        friendScarecrow.enabled = true;
        used = true;
    }
}
/* 
private void OnTriggerStay2D(Collider2D collision)
    {
        if (mouseButtonReleased)
        {
            var mergingScript = collision.gameObject.GetComponent<Merging>();
            if (mergingScript != null && level == mergingScript.level)
            {
                if (nextPumpkin != null)
                {
                    Instantiate(nextPumpkin, transform.position, quaternion.identity);
                    mouseButtonReleased = false;
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
            EnemyScareCrow enemyScareCrow = collision.GetComponent<EnemyScareCrow>();
            if (enemyScareCrow != null && enemyScareCrow._satisfied != true){
                Destroy(gameObject);
                enemyScareCrow._satisfied = true;
                enemyScareCrow.getHead(GetComponent<Sprite>());
            }
            else {
                FriendScarecrow getPumpkinHead = collision.GetComponent<GetPumpkinHead>();
                if (friendScarecrow != null && friendScarecrow.active == false){
                friendScarecrow.SetLevel(level);
                }
            }
            
        }
        mouseButtonReleased = false;
    }
*/