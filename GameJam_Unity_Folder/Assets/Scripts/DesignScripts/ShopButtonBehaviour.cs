using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonBehaviour : MonoBehaviour
{
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShop(){
        shop.SetActive(!shop.activeInHierarchy);
    }
    public void CloseShop(){
        shop.SetActive(false);
    }
    public void TriggerTestButton(){
        Debug.Log("button is working");
    }
}
