using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCooldown : MonoBehaviour
{
    [SerializeField] private float cooldown = 3f;
    [SerializeField] private Image cdFillImage;

    private bool _ready = true;
    
    void Start()
    {
        if(!_ready)
        {
            StartCoroutine(ActivateCoolDown());
        }
        else
        {
            cdFillImage.fillAmount = 0f;
        }
    }

    void Update()
    {
        if(_ready && Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(ActivateCoolDown());
        }
    }

    private IEnumerator ActivateCoolDown()
    {
        _ready = false;
        float currentTimePassed = 0f;
        cdFillImage.fillAmount = 1f;

        //yield return new WaitForSeconds(cooldown);
        do{
            currentTimePassed += Time.deltaTime;
            cdFillImage.fillAmount = 1f - currentTimePassed / cooldown;
            yield return null;
        }while(currentTimePassed < cooldown);

        cdFillImage.fillAmount = 0f;
        _ready = true;
    }
}
