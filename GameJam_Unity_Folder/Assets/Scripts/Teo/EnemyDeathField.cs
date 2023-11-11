using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
