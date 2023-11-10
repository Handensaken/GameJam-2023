using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    public float spawnSpeed;
    public GameObject pumpkinSpawnObject;
    public GameObject pumpkinQueen;
    private Vector3 screenCoordinates;
    public float inset = 0;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnSpeed)
        {
            spawn();
            currentTime = 0;
        }
    }
    public void spawn()
    {
        float xPos;
        float yPos;
        int dontBreak = 0;
        while (true)
        {
            dontBreak++;
            xPos = UnityEngine.Random.Range(-screenCoordinates.x, screenCoordinates.x);
            yPos = UnityEngine.Random.Range(-screenCoordinates.y, screenCoordinates.y);

            Vector2 pumpKinQueenSize = pumpkinQueen.GetComponent<BoxCollider2D>().bounds.size;
            if(xPos >= pumpkinQueen.transform.position.x - pumpKinQueenSize.x * 0.5 - 0.05f 
            && xPos <= pumpkinQueen.transform.position.x + pumpKinQueenSize.x * 0.5 + 0.05 
            && yPos >= pumpkinQueen.transform.position.y - pumpKinQueenSize.y * 0.5 - 0.05f 
            && yPos <= pumpkinQueen.transform.position.y + pumpKinQueenSize.y * 0.5 + 0.05){
            }
            else {
                break;
            }
            if (dontBreak >= 60){
                break;
            }
        }



        Instantiate(pumpkinSpawnObject, new Vector3(xPos, yPos, 0), quaternion.identity);
    }
}
