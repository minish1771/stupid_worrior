using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class elemental_cost_manager : MonoBehaviour
{

    public gamemanager gm;
    GameObject target;

    public Transform upbtn;
    public Transform downbtn;
    public Transform decidebtn;
    public Text text_total_cost;

    int timecost;
    int total_cost;
    int stage;
    int sum_cost;
    Text cost;
    
    //elemental's cost
    fire fire_cost;
    bush bush_cost;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gamemanager>();
    
        cost = GameObject.Find("Canvas").transform.Find("cost").GetComponent<Text>();
        stage = gm.getstage_ind();
        total_cost = gm.get_tot_timecost(stage);

    }

    // Update is called once per frame 
    void Update()
    {
        text_total_cost.text += (total_cost - sum_cost).ToString();
    }
    public void costdown()
    {
        if (timecost > 0)
        {
            timecost--;
        }
        
        cost.text = timecost.ToString();
     
    }
    public void costup()
    {
        if (total_cost > timecost + sum_cost)
            timecost++;
        
        cost.text = timecost.ToString();
    }
    public void costdecide()
    {
        
        target.GetComponent<element>().set_timecost(timecost);
        sum_cost += timecost;
        timecost = 0;
        upbtn.gameObject.SetActive(false);
        downbtn.gameObject.SetActive(false);
        decidebtn.gameObject.SetActive(false);
        cost.gameObject.SetActive(false);
    }

   
    public void set_target(GameObject a)
    {
        target = a;
    }
    public bool more_element()
    {
        return total_cost == sum_cost;
    }
}
