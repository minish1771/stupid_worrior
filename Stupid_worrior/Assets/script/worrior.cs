using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worrior : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    Animator ani;
    private bool wor_isable;
    public gamemanager gm;
    public float speed;
    void Start()
    {
        
    }
    //소환 위치 정하기 ->좌표에 0.5f더하기
    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
     
    }
    // Update is called once per frame
    void Update()
    {
   
    }
    private void FixedUpdate()
    {
        RaycastHit2D walk=Physics2D.Raycast(rigid.position,Vector2.down,0.7f,LayerMask.GetMask("tile"));
        Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));
        if (walk.collider != null)
        {
            
            rigid.velocity = new Vector2(speed, 0);
            

        }
      

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 7&&gm.get_able())
            gameObject.SetActive(false);
    }
}
