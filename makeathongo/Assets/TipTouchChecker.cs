using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTouchChecker : MonoBehaviour {

    public GameObject EnBody;

    public GameObject Parent;



    public GameObject Sword;
  
    void Start()
    {
        Debug.Log("The tip started");
    }

    void OnTriggerEnter(Collider other)
    {
     //   Debug.Log("Logged hit");
        if (other.gameObject == EnBody)
        {

        }
    }

}
