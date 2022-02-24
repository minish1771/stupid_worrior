using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamemanager : MonoBehaviour
{

    public worrior wor;
    public monster mon;
    public GameObject firebtn;
    public GameObject playbtn;
    public GameObject bushbtn;
    public GameObject upbtn;
    public GameObject downbtn;
    public GameObject decidebtn;
    private grid gr;
    bool move_able = false;
    bool ele_able = false;
    private int[] total_timecost= { 5, 5, 5 };
    private int stage;
    int sum_cost;

    public Text time_text;
    float timer;
    bool timer_start;
    int m, s;

    // Start is called before the first frame update
    void Start()
    {
        gr = new grid(10, 10, 1);
       
    }
    private void Awake()
    {
        stage = 2;
        sum_cost = 0;
        timer_start = false;
        Time.timeScale = 0;
        
    }
    
    // Update is called once per frame
    void Update()
    {
      

        if (timer_start)
        {
            starttimer();
        }
    }
  
    public bool get_able()
    {
        return move_able;
        
    }
    public void on_play()
    {
        move_able =!move_able;
        if (move_able)
            Time.timeScale = 1;
        else Time.timeScale = 0;
       
    }
    void settimecost(int i)
    {
        total_timecost[stage] = i;
    }
   public void onfire()
    {
        Instantiate(Resources.Load("fire"), new Vector2(0, 0),Quaternion.identity);
    }
    public int get_tot_timecost(int stage)
    {
        return total_timecost[stage];
    }
    public int getstage_ind()
    {
        return stage;
    }
    public int get_sumcost()
    {
        return sum_cost;
    }
    public void set_sumcost(int cost)
    {
        sum_cost += cost;
    }
    void starttimer()
    {
        timer += Time.deltaTime;
        
        m = ((int)timer / 60 % 60);
        s = ((int)timer % 60);
        time_text.text = string.Format("{0} : {1} ",  m, s);
    }
    public void isstarttimer()
    {
        timer_start = !timer_start;
    }
    
    public float get_timer()
    {
        return timer;
    }

    
 
}
