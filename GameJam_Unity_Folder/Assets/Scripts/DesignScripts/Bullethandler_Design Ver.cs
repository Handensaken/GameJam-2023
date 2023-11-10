using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullethandler_DesignVer : MonoBehaviour
{
    private GameObject Enemy;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");

        Vector3 direction = Enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
