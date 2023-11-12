using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowDisplayManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _scareCrows = new List<GameObject>();
    [SerializeField] private List<Image> _levelImages = new List<Image>();

    [SerializeField] private List<Sprite> _levelSprites = new List<Sprite>();

    [SerializeField] private int test = 0;

    // Start is called before the first frame update
    void Start()
    {
        test = 0;
       /* foreach(GameObject g in _scareCrows){
            g.gameObject.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ActivateNextItem(int level){
       Debug.Log("Index is" + test);
       Debug.Log("total count" + _scareCrows.Count);
       Debug.Log(_scareCrows[test]);
       Debug.Log(_scareCrows[test].active);
        _scareCrows[test].active = true;
        _scareCrows[test].SetActive(true);
        _scareCrows[test].gameObject.SetActive(true);        
        _scareCrows[test].gameObject.active = true;
        //INGEN AV DEM FUCKING FUNKAR
    
        Debug.Log("Passed weird part");


        // ???????? wtfffff VARFÖR funkar den här inte
      //  _levelImages[test].sprite = _levelSprites[level-1];

        test++;
    }
}
