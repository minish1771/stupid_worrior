using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class element : MonoBehaviour
{
    
    public gamemanager gm;
    protected elemental_cost_manager ele;
    SpriteRenderer sprite;
    SpriteRenderer dup_sprite;
    protected  int timecost;
    bool isok = true;
    protected bool isbutton = true;

    public Text cost;
    bool isnotelement;
    //button
    public Transform upbtn;
    public Transform downbtn;
    public Transform decidebtn;



    GameObject duplicate_element=null;
    GameObject real_element = null;
    protected bool isdrag=false;

    // Start is called before the first frame update
    void Start()
    {

        gm = GameObject.Find("GameManager").GetComponent<gamemanager>();
        upbtn = GameObject.Find("Canvas").transform.Find("upbtn");
        downbtn = GameObject.Find("Canvas").transform.Find("downbtn");
        decidebtn = GameObject.Find("Canvas").transform.Find("decidebtn");
        cost= GameObject.Find("Canvas").transform.Find("cost").GetComponent<Text>();
        ele = GameObject.Find("elemental").GetComponent<elemental_cost_manager>();
     


    }

    // Update is called once per frame
    protected virtual void Awake()
    {

        sprite = GetComponent<SpriteRenderer>();
        Vector3 position = new Vector3(0.5f, 0.5f, -12);
        timecost = 0;
        

        // gameObject.transform.position = Camera.main.ViewportToWorldPoint(position);
    }


    // Update is called once per frame
   protected virtual void Update()
    {
        if (ele.more_element())
            isnotelement = true;
      
    }

   
    public void unactive()
    {
         
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        
        if (!isnotelement)
        {
            var ele = Resources.Load(gameObject.name);

            Vector2 pos = gameObject.transform.position;
            duplicate_element = (GameObject)Instantiate(ele, gameObject.transform.position, Quaternion.identity);
            duplicate_element.GetComponent<element>().isbutton = false;
            dup_sprite = duplicate_element.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, 0.5f);
        }
    }
    private void OnMouseDrag()
    {
        if (!isnotelement)
        {
           Collider2D collision1 = Physics2D.OverlapBox(duplicate_element.transform.position, new Vector2(1f, 1f), 0, gameObject.layer);
 

            if (collision1 != null)
            {
                Debug.Log(collision1.name);
                if (collision1.tag != "elemental")
                    dup_sprite.color = new Color(1, 0, 0, 0.5f);
                else
                    dup_sprite.color = new Color(0, 1, 0, 0.5f);
            }
            else
            {
                dup_sprite.color = new Color(0, 1, 0, 0.5f);

            }
            Vector2 mouseposition = Input.mousePosition;

            mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
            Vector2 selectposition = new Vector2(Mathf.FloorToInt(mouseposition.x) + 0.5f, Mathf.FloorToInt(mouseposition.y) + 0.5f);
            duplicate_element.transform.position = selectposition;

        }
    }

    private void OnMouseUp()
    {
        if (!isnotelement)
        {
            Vector2 mouseposition = Input.mousePosition;
            mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
            Vector2 selectposition = new Vector2(Mathf.FloorToInt(mouseposition.x) + 0.5f, Mathf.FloorToInt(mouseposition.y) + 0.5f);
            duplicate_element.transform.position = selectposition;
            sprite.color = new Color(1, 1, 1, 1);
            cost.text = 0.ToString();
            dup_sprite.color = new Color(1, 1, 1, 1);
           
            upbtn.gameObject.SetActive(true);
            downbtn.gameObject.SetActive(true);
            decidebtn.gameObject.SetActive(true);
            upbtn.transform.position = Camera.main.WorldToScreenPoint(duplicate_element.transform.position + new Vector3(0.5f, 0.5f, 0));
            downbtn.transform.position = Camera.main.WorldToScreenPoint(duplicate_element.transform.position + new Vector3(0.5f, -0.5f, 0));
            decidebtn.transform.position = Camera.main.WorldToScreenPoint(duplicate_element.transform.position + new Vector3(0.5f, 0, 0));
            cost.gameObject.SetActive(true);
            cost.transform.position = Camera.main.WorldToScreenPoint(duplicate_element.transform.position + new Vector3(-0.5f, 0, 0));
            
            ele.set_target(gameObject);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector2(1f, 1f));
    }
    void get_time(int a)
    {

    }
    public void set_timecost(int a)
    {
        duplicate_element.GetComponent<element>().timecost = a ;
       
    }
}
