using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDust : MonoBehaviour
{
    public GameObject thisObj;
    public GameObject starDust;
    public int gridX;
    public int gridY;
    public int spacing;

    void Start()
    {
        float startIn = 1;
        float every = 5;
        InvokeRepeating("spawn", startIn, every);
    }


    void spawn()
    {
        for (var y = 0; y < gridY; y++)
        {
            for (var x = 0; x < gridX; x++)
            { 
                float randomX = Random.Range(0.0f, 5.0f);
            
                starDust.transform.localScale = new Vector3(Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f), 1);
                var pos = new Vector3(thisObj.transform.position.x + randomX , thisObj.transform.position.y + randomX, 0);
                Instantiate(starDust,pos , Quaternion.identity);
            }
        }
    
        
    }
}