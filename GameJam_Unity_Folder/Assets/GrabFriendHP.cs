using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrabFriendHP : MonoBehaviour
{
    [SerializeField] private GameObject fren;
    // Start is called before the first frame update


    private TextMeshProUGUI ghee;
    void Start()
    {
        ghee = GetComponent<TextMeshProUGUI>();;
        Debug.Log(ghee);   
    }

    // Update is called once per frame
    void Update()
    {
        ghee.text = fren.GetComponent<FriendScarecrow>().level.ToString();       
    }
}
