using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grid : MonoBehaviour
{
    private int width;
    private int height;
    private int cellsize;

    private int[,] gridarray;

    public grid(int width, int height, int cellsize)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        gridarray = new int[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                gridarray[x, y] = 0;
                
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 999);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x , y+1), Color.white, 999);
                Debug.DrawLine(GetWorldPosition(x+1, y), GetWorldPosition(x+1, y + 1), Color.white, 999);
                Debug.DrawLine(GetWorldPosition(x, y+1), GetWorldPosition(x+1, y+1), Color.white, 999);

            }
        }
    }
    private Vector3 GetWorldPosition(int x,int y)
    {
        return new Vector3(x, y) * cellsize;
    }
    // Start is called before the first frame update
    void Start()
    {
       
      
    }

    // Update is called once per frame
     
    void Update()
    {
        
    }
}
