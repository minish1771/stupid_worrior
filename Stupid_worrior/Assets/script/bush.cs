using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class bush : element
{
    Collider2D collision2;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Update()
    {
        
        base.Update();
        collision2 = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(1f, 1f), 0, 8);
        
        if (collision2 != null)
        {
            Debug.Log(this.gameObject.name + " child overlap : " + collision2.name);


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(1);
        if (collision.tag != "elemental")
            Destroy(this.gameObject);
    }


}
