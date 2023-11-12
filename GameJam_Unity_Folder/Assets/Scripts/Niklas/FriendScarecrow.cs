using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendScarecrow : MonoBehaviour
{
    [SerializeField] private GameObject _indicator;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Vector2 mousePosition;
    private EnemyScareCrow target;
    private float timer = 0.25f;
    private float currentTime;
    public int level;
    public bool active = false;
    public bool inCombat = false;
    public int baseDamage = 1;
    private Animator anim;
    // Start is called before the first frame update

    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.SetBool("SexMachines", false);
         anim.SetBool("Start", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(target);
        if (target != null)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timer)
            {
                target.scareCrowHP -= baseDamage + level;
                currentTime = 0;
            }
        }
        if(target == null){
            anim.SetBool("SexMachines", false);
        }
    }
    private void OnMouseDown()
    {
        if (active)
        {
            if (target == null)
            {
                mouseButtonReleased = false;
                offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
                offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            }
        }
    }
    private void OnMouseDrag()
    {
        if (active)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
        }
    }
    private void OnMouseUp()
    {
        if (active)
        {
            mouseButtonReleased = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (active)
        {
            if (mouseButtonReleased != false)
            {
                EnemyScareCrow enemyScareCrow = collision.GetComponent<EnemyScareCrow>();
                if (enemyScareCrow != null && enemyScareCrow.inCombat != true && enemyScareCrow._satisfied == false)
                {
                    enemyScareCrow.inCombat = true;
                    target = enemyScareCrow;
                    mouseButtonReleased = false;
                    anim.SetBool("SexMachines", true);
                }
            }
        }
    }
    public void setLevel(int lvl)
    {
        if (active == false)
        {
            level = lvl;
            active = true;
            //hehe me in ur code :3
            anim.SetBool("Start", true);
            Debug.Log("are you running a bunch?");
            _indicator.GetComponent<CrowDisplayManager>().ActivateNextItem(level);
        }
        else
        {
            Debug.Log("bruh how is set lvl playing?");
        }

    }
}
