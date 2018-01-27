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
        float every = 1;
        InvokeRepeating("spawn", startIn, every);
    }


    void spawn()
    {
        Instantiate(starDust, thisObj.transform.position,Quaternion.identity);
    }
}