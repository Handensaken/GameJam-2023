using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScarecrow : MonoBehaviour
{
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Vector2 mousePosition;
    public EnemyScareCrow target;
    private float timer = 0.25f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timer)
            {
                target.scareCrowHP--;
                currentTime = 0;
            }
        }
    }
    private void OnMouseDown()
    {
        if (target == null)
        {
            mouseButtonReleased = false;
            offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

        }
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
            EnemyScareCrow enemyScareCrow = collision.GetComponent<EnemyScareCrow>();
            if (enemyScareCrow != null && enemyScareCrow.inCombat != true && enemyScareCrow._satisfied == false)
            {
                enemyScareCrow.inCombat = true;
                target = enemyScareCrow;
            }
        }
        mouseButtonReleased = false;
    }
}
