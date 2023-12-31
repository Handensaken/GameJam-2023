using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScareCrow : MonoBehaviour
{
    //[SerializeField] private MotherPumpkinHP motherPumpkinHP;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int hungerDamage = 10;
    public int scareCrowHP;
    public int pumpkinCraving = 1;
    private Animator anim;
    [HideInInspector] public bool inCombat = false;
    //[NonSerialized]
    //public enemyScareCrowStats stats;
    [HideInInspector] public GameObject target;

    [HideInInspector] public bool _satisfied = false;


    void Start()
    {
       
        //Max trademark animation insertion
        anim = this.GetComponent<Animator>();
        //scareCrowHP = stats.maxHp;
    }
    
    //animationerna måste kontrolleras via Update, annars går det inte att uppdatera dem av whatever reason
    void Update(){
        anim.SetBool("fight",inCombat);
    }

 
    void FixedUpdate()
    {
        if (scareCrowHP <= 0)
        {
            Destroy(gameObject);
        }
        if (inCombat == false)
        {
            if (!_satisfied)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
                Vector3 moveAway = Vector3.MoveTowards(transform.position, target.transform.position - target.transform.position, speed * Time.deltaTime / 30);
                transform.position += moveAway;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            Debug.Log(hungerDamage);
            MotherPumpkinHP.LoseHealth(hungerDamage);
            _satisfied = true;
        }
    }

    public void AssignRankValues(int pumpkinCraveingLevel, int hp, float moveSpeed, int dmg)
    {
        pumpkinCraving = pumpkinCraveingLevel;
        scareCrowHP = hp;
        speed = moveSpeed;
        hungerDamage = dmg;
    }
}
