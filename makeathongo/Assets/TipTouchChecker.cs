using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTouchChecker : MonoBehaviour {

    public string TagForFronthalf;
    public string TagForBackHalf;

    public GameObject Parent;

    public GameObject EnSword;

    public GameObject Sword;
  
    void Start()
    {
        Debug.Log("The tip started");
    }

    void OnTriggerEnter(Collider other)
    {
     //   Debug.Log("Logged hit");
        if (other.tag == TagForBackHalf)
        {
            if (Parent == EnSword)
            {
                Parent.GetComponent<EnemySword>().SwitchToDeflecthard();
            }
            else if (Parent == Sword)
            {
               // Parent.GetComponent<SwordGod>().Deflecthard();
            }
        }

        else if (other.tag == TagForFronthalf)
        {
            if (Parent == EnSword)
            {
                Parent.GetComponent<EnemySword>().SwitchToDeflectSoft();
            }


            else if (Parent == Sword)
            {
               // Parent.GetComponent<SwordGod>().DeflectSoft();
            }
        }
    }

}
