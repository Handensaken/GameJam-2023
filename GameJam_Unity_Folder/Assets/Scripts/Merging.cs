using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Merging : MonoBehaviour
{
    public GameObject nextPumpkin;
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    private static bool mouseButtonReleased;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown(){
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }
    private void OnMouseDrag(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }
    private void OnMouseUp(){
        mouseButtonReleased = true;
    }
    private void OnTriggerStay2D(Collider2D collision){
        string thisGameobjectName;
        string collisionGameobjectName;

        thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if (mouseButtonReleased && thisGameobjectName == collisionGameobjectName){
            if (nextPumpkin != null){
                Instantiate(nextPumpkin, transform.position, quaternion.identity);
                mouseButtonReleased = false;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            
        }
    }
}