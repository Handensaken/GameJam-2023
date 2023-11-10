using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPumpkin : MonoBehaviour
{   
    [SerializeField] private GameObject pumpkinPrefab;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private List<GameObject> endPoints;
    [SerializeField] private float throwTime = 1f;
    [SerializeField] private AnimationCurve throwDistanceArc;
    [SerializeField] private AnimationCurve throwHeightArc;
    [SerializeField] private float arcHeightMultiplier = 3f;
    
    [Space(6)]
    [SerializeField] private VoidEventSO throwInArcSO;

    public static ThrowPumpkin Instance;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    private void OnEnable() 
    {
        throwInArcSO.OnEventRaised += CustomArcThrow;
    }

    private void OnDisable() 
    {
        throwInArcSO.OnEventRaised -= CustomArcThrow;  
    }

    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("The dawn has arrived");
            StartCoroutine(SunsetArc(pumpkin.transform, startPoint.transform.position, 
                endPoint.transform.position, sunsetHeight, throwTime));
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("YEET!");
            StartCoroutine(ThrowInArc(pumpkin.transform, startPoint.transform.position,
                endPoint.transform.position, throwTime));
        }
    }*/

    private void CustomArcThrow()
    {
        var endPoint = endPoints[Random.Range(0, endPoints.Count - 1)];
        var newPumpkin = Instantiate(pumpkinPrefab);

        StartCoroutine(ThrowInArc(newPumpkin.transform, startPoint.transform.position,
                endPoint.transform.position, throwTime));
    }

    private IEnumerator ThrowInArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        float arcThrowTime
        )
    {
        float currentTime = 0f;

        do{
            currentTime += Time.deltaTime / arcThrowTime;
            mover.position = Vector2.Lerp(start, end, throwDistanceArc.Evaluate(currentTime));
            mover.position += new Vector3(0f, (throwHeightArc.Evaluate(currentTime)) * arcHeightMultiplier, 0f);
            yield return null;
        }while(currentTime < 1f);
        
        mover.position = end;
    }
}
