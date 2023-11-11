using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScareCrow : MonoBehaviour
{
    [SerializeField] private MotherPumpkinHP motherPumpkinHP;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int hungerDamage = 10;
    public bool inCombat = false;
    //[NonSerialized]
    public enemyScareCrowStats stats;
    public int scareCrowHP;

    public GameObject target;

    public bool _satisfied = false;
    void Start()
    {
        scareCrowHP = stats.maxHp;
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
                Vector3 moveAway = Vector3.MoveTowards(target.transform.position, transform.position, speed * Time.deltaTime);
                transform.position += moveAway;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            motherPumpkinHP.LoseHealth(hungerDamage);
            _satisfied = true;
        }
    }
    public void getHead(Sprite sprite)
    {

    }
}
