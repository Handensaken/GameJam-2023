using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrabFriendHP : MonoBehaviour
{
    [SerializeField] private GameObject fren;
    // Start is called before the first frame update


    private TMP_Text ghee;
    void Start()
    {
        ghee = GetComponent<TextMeshPro>().TMP_Text;
        Debug.Log(ghee);   
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<TextMeshPro>().text = fren.GetComponent<FriendScarecrow>().level.ToString();       
    }
}
