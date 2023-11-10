using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    public float spawnSpeed;
    private float screenX;
    private float screenY;
    public GameObject pumpkinSpawnObject;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenX = Screen.width / 200;
        screenY = Screen.height / 200;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnSpeed){
            spawn();
            currentTime = 0;
        }
    }
    public void spawn(){
        float xPos = UnityEngine.Random.Range(-0.5f * screenX, screenX * 0.5f);
        float yPos = UnityEngine.Random.Range(-0.5f * screenY, screenY * 0.5f);

        Instantiate(pumpkinSpawnObject, new Vector3(xPos, yPos, 0), quaternion.identity);
    }
}
