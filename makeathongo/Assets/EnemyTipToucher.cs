using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTipToucher : MonoBehaviour {

    public string TagForFronthalf;
    public string TagForBackHalf;

    public GameObject Parent;

   
  
    void Start()
    {
        Debug.Log("The tip started");
    }

    void OnTriggerEnter(Collider other)
    {
     //   Debug.Log("Logged hit");
        if (other.tag == TagForBackHalf)
        {
           
                Parent.GetComponent<EnemySword>().SwitchToDeflecthard();
            
            
             

            
        }

        else if (other.tag == TagForFronthalf)
        {
          
                Parent.GetComponent<EnemySword>().SwitchToDeflectSoft();

            


          
        }
    }

}
