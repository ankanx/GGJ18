using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextlevel : MonoBehaviour
{
    public int level;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(level);
        }

    }
}
