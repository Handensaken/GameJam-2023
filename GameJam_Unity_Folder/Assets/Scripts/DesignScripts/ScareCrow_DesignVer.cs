using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ScareCrow_DesignVer : MonoBehaviour
{
    // Start is called before the first frame update
    private bool busy;
    public GameObject Message;
    public Transform messagePos;

    private float timer;
    private int EnemyAmount;
    public int Headlevel;
    private bool IsShowing;
    void Start()
    {
        IsShowing = false;
        Headlevel = 2;
    }

    // Update is called once per frame
    void Update()
    {

        //timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Så länge SwordCrowen inte är busy så ska den börja följa efter monster, om det ska göras via en OnEnter eller om den alltid
        //ska göra det är upp till er programmerare som behöver få det att fungera.
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        //Just nu hanterar denna bara en fiende. För att kunna hantera flera måste den först kolla ifall dens level är högt nog för att
        //attackera en till fiende. Den kan slåss mot en till ifall huvudets level är högre än antalet fiender den redan slåss mot. Är
        //den level 4 kan den slåss mot 4 fiender (detta kan ändras i framtiden)
        timer += 0.1f;
        Debug.Log(timer);
        if (other.gameObject.tag == "Enemy" && timer > 2)
        {
            if (IsShowing)
            {
                Message.SetActive(false);
                IsShowing = false;
                
            }
            else
            {
                Message.SetActive(true);
                IsShowing = true;
            }

            timer = 0;
            //damage = headlevel;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited Trigger");
    }


}
