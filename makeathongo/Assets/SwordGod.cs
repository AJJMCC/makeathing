using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGod : MonoBehaviour {
    private Animator MyAnim;

    public GameObject start;
    public GameObject end;

    public GameObject EnemySwordObj;
    private EnemySword enscript;

	void Start ()
    {
        enscript = EnemySwordObj.GetComponent<EnemySword>();
        MyAnim = this.GetComponent<Animator>();
	}
	


	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Lungo();
        }
	}

    void Lungo()
    {
        MyAnim.SetTrigger("Lunge");
        enscript.SwitchToDefence();
    }

    public void DisableControl()
    {
        start.GetComponent<MouseReact>().Control = false;
        end.GetComponent<MouseReact>().Control = false;
    }

    public void EnableControl()
    {
        start.GetComponent<MouseReact>().Control = true;
        end.GetComponent<MouseReact>().Control = true;
        enscript.SwitchToMove();
    }
}
