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
        //S� l�nge SwordCrowen inte �r busy s� ska den b�rja f�lja efter monster, om det ska g�ras via en OnEnter eller om den alltid
        //ska g�ra det �r upp till er programmerare som beh�ver f� det att fungera.
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        //Just nu hanterar denna bara en fiende. F�r att kunna hantera flera m�ste den f�rst kolla ifall dens level �r h�gt nog f�r att
        //attackera en till fiende. Den kan sl�ss mot en till ifall huvudets level �r h�gre �n antalet fiender den redan sl�ss mot. �r
        //den level 4 kan den sl�ss mot 4 fiender (detta kan �ndras i framtiden)
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
