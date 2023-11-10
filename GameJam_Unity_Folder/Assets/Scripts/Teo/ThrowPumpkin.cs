using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPumpkin : MonoBehaviour
{   
    [Header("General")]
    [SerializeField] private GameObject pumpkin;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private float throwTime = 1f;

    [Header("Sunset")]
    [SerializeField] private float sunsetHeight = 2f;

    [Header("Throw arc")]
    [SerializeField] private AnimationCurve throwDistanceArc;
    [SerializeField] private AnimationCurve throwHeightArc;
    [SerializeField] private float arcHeightMultiplier = 3f;
    


    // Update is called once per frame
    void Update()
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
    }

    private IEnumerator ThrowInArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        //float extraHeight, // Set this to negative if you want to flip the arc.
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

    private IEnumerator SunsetArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        float radius, // Set this to negative if you want to flip the arc.
        float duration) 
        {

        Vector2 difference = end - start;
        float span = difference.magnitude;

        // Override the radius if it's too small to bridge the points.
        float absRadius = Mathf.Abs(radius);
        if(span > 2f * absRadius)
            radius = absRadius = span/2f;

        Vector2 perpendicular = new Vector2(difference.y, -difference.x)/span;
        perpendicular *= Mathf.Sign(radius) * Mathf.Sqrt(radius*radius - span*span/4f);

        Vector2 center = start + difference/2f + perpendicular;

        Vector2 toStart = start - center;
        float startAngle = Mathf.Atan2(toStart.y, toStart.x);

        Vector2 toEnd = end - center;
        float endAngle = Mathf.Atan2(toEnd.y, toEnd.x);

        // Choose the smaller of two angles separating the start & end
        float travel = (endAngle - startAngle + 5f * Mathf.PI) % (2f * Mathf.PI) - Mathf.PI;

        float progress = 0f;
        do {
            float angle = startAngle + progress * travel;
            mover.position = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime/duration;
            yield return null;
        } while (progress < 1f);

        mover.position = end;
    }
}
