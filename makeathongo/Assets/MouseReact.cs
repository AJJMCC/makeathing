using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseReact : MonoBehaviour {


    /* Variables */
    public float minXpos = 10;
    public float maxXpos = 100;
    public float minYpos = 10;
    public float maxYpos = 100;


    public float LerpTime;
    public bool Control;
    public GameObject Blade;

    // Use this for initialization
    void Start()
    {
        Control = true;
        minXpos *= 0.01f;
        minXpos *= Screen.width;
        maxXpos *= 0.01f;
        maxXpos *= Screen.width;

        minYpos *= 0.01f;
        minYpos *= Screen.height;
        maxYpos *= 0.01f;
        maxYpos *= Screen.height;
    }

    // Update is called once per frame
    void Update()
    {if (Control)
        {
            dostuff();
        }
      
    }

    void dostuff()
    {

        Vector3 inputVec = Input.mousePosition;
        inputVec.z = -Camera.main.transform.position.z + transform.position.z;

        inputVec.x = (inputVec.x < minXpos) ? minXpos : inputVec.x;
        inputVec.x = (inputVec.x > maxXpos) ? maxXpos : inputVec.x;
        inputVec.y = (inputVec.y < minYpos) ? minYpos : inputVec.y;
        inputVec.y = (inputVec.y > maxYpos) ? maxYpos : inputVec.y;

        Vector3 desiredPos = Camera.main.ScreenToWorldPoint(inputVec);

        transform.position = Vector3.Lerp(transform.position,desiredPos,LerpTime);

        transform.rotation = Blade.transform.rotation;
    }


    //public float minXpos = 10;
    //public float maxXpos = 100;
    //public float minYpos = 10;
    //public float maxYpos = 100;



    //// Use this for initialization
    //void Start ()
    //{
    //    minXpos *= 0.01f;
    //    minXpos *= Screen.width;
    //    maxXpos *= 0.01f;
    //    maxXpos *= Screen.width;


    //    minYpos *= 0.01f;
    //    minYpos *= Screen.height;
    //    maxYpos *= 0.01f;
    //    maxYpos *= Screen.height;
    //}
    //void Update()
    //{
    //    Dostuff();
    //}

    //void Dostuff()
    //{

    //    Vector3 inputVec = Input.mousePosition;
    //    inputVec.z = -Camera.main.transform.position.z;

    //    inputVec.x = (inputVec.x < minXpos) ? minXpos : inputVec.x;
    //    inputVec.x = (inputVec.x > maxXpos) ? maxXpos : inputVec.x;

    //    inputVec.y = (inputVec.y < minYpos) ? minYpos : inputVec.y;
    //    inputVec.y = (inputVec.y > maxYpos) ? maxYpos : inputVec.y;

    //    Vector3 desiredPos = Camera.main.ScreenToWorldPoint(inputVec);

    //    transform.position = desiredPos;
    //}


}
