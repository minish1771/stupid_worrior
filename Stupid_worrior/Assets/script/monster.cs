using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator ani;
    public gamemanager gm;
    public float speed;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
  
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.get_able())
        {
           
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D walk = Physics2D.Raycast(rigid.position, Vector2.down, 1f, LayerMask.GetMask("tile"));
        Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));
        if (walk.collider != null)
        {
            rigid.velocity = new Vector2((-1)*speed, 0);
            
        }
      
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7&&gm.get_able())
            gameObject.SetActive(false);
    }
}
