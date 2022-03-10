using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class fire : element
{

    // Start is called before the first frame update
    float time_life=0.5f;
    bool issynergy=false;
 
    Collider2D collision2;
    SpriteRenderer sprite1;

    protected override void Awake()
    {
        base.Awake();
        sprite1 = GetComponent<SpriteRenderer>();
    }
    protected override void Update()
    {
        
        base.Update();
        
        if (!isbutton)
        {
       
            if (gm.get_able())
            {
                if (gm.get_timer() > timecost && !issynergy)
                    Destroy(gameObject);
            }
            collision2 = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(1f, 1f), 0, 7);

            if (collision2 != null)
            {
                Debug.Log(this.gameObject.name+" child overlap : " + collision2.name);

                if (collision2.name == "bush")
                {
                    Debug.Log("test");
                    issynergy = true;
                }

            }
        }


    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(1);
        if(collision.tag!="elemental")
        Destroy(this.gameObject);
    }

}
