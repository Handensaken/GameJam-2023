using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Merging : MonoBehaviour
{
    public GameObject nextPumpkin;
    public int level;
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
        }
        mouseButtonReleased = false;
    }
}