using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Merging : MonoBehaviour
{
    [SerializeField] private TotalListCheckEvent pumpkinListEvent;
    public GameObject nextPumpkin;
    public int level;
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    private bool mouseButtonReleased = false;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }
    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }
    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        Debug.Log("hej");
    }
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

                    Debug.LogWarning("One!");
                    pumpkinListEvent.RaiseEvent(nextPumpkin, true);
                    //Debug.LogWarning("Two!");
                    //pumpkinListEvent.RaiseEvent(collision.gameObject, false);
                    //Debug.LogWarning("Three!");
                    //pumpkinListEvent.RaiseEvent(gameObject, false);
                    Debug.Log("Done?");

                    mouseButtonReleased = false;

                    //Destroy(collision.gameObject);
                    mergingScript.FruitSuicide();
                    FruitSuicide();
                }
            }
            EnemyScareCrow enemyScareCrow = collision.GetComponent<EnemyScareCrow>();
            if (enemyScareCrow != null && enemyScareCrow._satisfied != true)
            {
                pumpkinListEvent.RaiseEvent(gameObject, false);
                Destroy(gameObject);
                enemyScareCrow._satisfied = true;
                enemyScareCrow.getHead(GetComponent<Sprite>());
            }
        }
        mouseButtonReleased = false;
    }

    public void FruitSuicide()
    {
        Debug.Log("New fruit, new me!");
        pumpkinListEvent.RaiseEvent(gameObject, false);
        Destroy(gameObject);
    }
}