using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour {

    public GameObject menu;

    public void Activate()
    {

            menu.gameObject.SetActive(false);
       
    }
}
