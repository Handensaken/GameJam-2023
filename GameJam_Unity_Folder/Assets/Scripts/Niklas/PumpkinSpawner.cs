//using System;
using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    public float spawnSpeed;
    [Space(8)]
    public GameObject lv1Pumpkin;
    private int lv1SpawnChance = 100;

    public GameObject lv2Pumpkin;
    private int lv2SpawnChance = 0;

    public GameObject lv3Pumpkin;
    private int lv3SpawnChance = 0;

    public GameObject lv4Pumpkin;
    private int lv4SpawnChance = 0;

    [Space(8)]
    public GameObject pumpkinQueen;
    private Vector3 screenCoordinates;
    public float inset = 0;
    private float currentTime = 0;

    [SerializeField] private float throwTime = 1f;
    [SerializeField] private AnimationCurve throwDistanceArc;
    [SerializeField] private AnimationCurve throwHeightArc;
    [SerializeField] private float arcHeightMultiplier = 3f;

    [Space(6)]
    [SerializeField] private VoidEventSO throwInArcSO;
    [SerializeField] private VoidEventSO buyFasterSpawning;
    [SerializeField] private SendNewPercentEventSO newOddsEvent;


    void Start()
    {
        screenCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnEnable()
    {
        buyFasterSpawning.OnEventRaised += FasterSpawnRate;
        newOddsEvent.OnEventRaised += AdjustSpawnOdds;
    }

    private void OnDisable()
    {
        buyFasterSpawning.OnEventRaised -= FasterSpawnRate;
        newOddsEvent.OnEventRaised -= AdjustSpawnOdds;
    }

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
            xPos = UnityEngine.Random.Range(-screenCoordinates.x + inset, screenCoordinates.x - inset);
            yPos = UnityEngine.Random.Range(-screenCoordinates.y + inset, screenCoordinates.y - inset);

            Vector2 pumpKinQueenSize = pumpkinQueen.GetComponent<BoxCollider2D>().bounds.size;
            if (xPos >= pumpkinQueen.transform.position.x - pumpKinQueenSize.x * 0.5 - 0.05f
            && xPos <= pumpkinQueen.transform.position.x + pumpKinQueenSize.x * 0.5 + 0.05
            && yPos >= pumpkinQueen.transform.position.y - pumpKinQueenSize.y * 0.5 - 0.05f
            && yPos <= pumpkinQueen.transform.position.y + pumpKinQueenSize.y * 0.5 + 0.05)
            {
            }
            else
            {
                break;
            }
            if (dontBreak >= 60)
            {
                break;
            }
        }

        //Instantiate(pumpkinSpawnObject, new Vector3(xPos, yPos, 0), quaternion.identity);
        var newPumpk = Instantiate(RandomizeNextPumpkin());
        StartCoroutine(ThrowInArc(newPumpk.transform, pumpkinQueen.transform.position, new Vector2(xPos, yPos), throwTime));
    }

    private IEnumerator ThrowInArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        float arcThrowTime
        )
    {
        throwInArcSO.RaiseEvent();
        float currentTime = 0f;

        do
        {
            currentTime += Time.deltaTime / arcThrowTime;
            mover.position = Vector2.Lerp(start, end, throwDistanceArc.Evaluate(currentTime));
            mover.position += new Vector3(0f, (throwHeightArc.Evaluate(currentTime)) * arcHeightMultiplier, 0f);
            yield return null;
        } while (currentTime < 1f);

        mover.position = end;
    }

    private GameObject RandomizeNextPumpkin()
    {
        int rand = UnityEngine.Random.Range(1, 101);

        if (rand <= lv1SpawnChance)
        {
            return lv1Pumpkin;
        }
        else if (rand - lv1SpawnChance <= lv2SpawnChance)
        {
            return lv2Pumpkin;
        }
        else if (rand - lv1SpawnChance - lv2SpawnChance <= lv3SpawnChance)
        {
            return lv3Pumpkin;
        }
        else
        {
            return lv4Pumpkin;
        }
    }

    private void AdjustSpawnOdds(int lv1Chance, int lv2Chance, int lv3Chance, int lv4Chance)
    {
        lv1SpawnChance = lv1Chance;
        lv2SpawnChance = lv2Chance;
        lv3SpawnChance = lv3Chance;
        lv4SpawnChance = lv4Chance;
    }

    private void FasterSpawnRate()
    {
        spawnSpeed -= 1f;
    }
}
