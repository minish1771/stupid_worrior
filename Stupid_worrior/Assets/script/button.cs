using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    SpriteRenderer sprite;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
     
     
    }

    public void OnDrag(PointerEventData eventData)
    {
      

        Vector2 mouseposition = Input.mousePosition;
        Debug.Log(mouseposition);

        
        Vector2 selectposition = new Vector2(Mathf.FloorToInt(mouseposition.x) + 0.5f, Mathf.FloorToInt(mouseposition.y) + 0.5f);
        this.transform.position = selectposition;
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
