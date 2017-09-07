using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGod : MonoBehaviour {
    private Animator MyAnim;

    public GameObject start;
    public GameObject end;


    public GameObject EnemySwordObj;
    public GameObject EnBlade;
    private EnemySword enscript;

    private float AttackCooldown;
    public float TimeBetAttacks;

    private float EnX;
    private float EnY;

    public float DeflectlerpSpeed;

    private bool SetAngletValues;

    void Start ()
    {
        enscript = EnemySwordObj.GetComponent<EnemySword>();
        MyAnim = this.GetComponent<Animator>();
	}
	


	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            if (AttackCooldown <= 0)
            {
                Lungo();

            }
        }
        AttackCooldown -= Time.deltaTime;
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
        AttackCooldown = TimeBetAttacks;
        SetAngletValues = false;
    }


    public void DeflectHard()
    {
        if (!SetAngletValues)
        {
            EnX = EnBlade.transform.rotation.x;
            EnY = EnBlade.transform.rotation.y;
            //  Lunging = false;
            SetAngletValues = true;
        }

        Vector3 Angle = new Vector3((EnX * 2) + 180, (EnY * 2) + 180, start.transform.rotation.z);
        start.transform.eulerAngles = Vector3.Lerp(start.transform.eulerAngles, Angle, DeflectlerpSpeed * 2);
        // Debug.Log("Tipsaidsoftdeflect");
    }

    public void DeflectSoft()
    {
        if (!SetAngletValues)
        {
            EnX = EnBlade.transform.rotation.x;
            EnY = EnBlade.transform.rotation.y;
          //  Lunging = false;
            SetAngletValues = true;
        }

        Vector3 Angle = new Vector3((EnX * 2) + 180, (EnY * 2) + 180, start.transform.rotation.z);
        start.transform.eulerAngles = Vector3.Lerp(start.transform.eulerAngles, Angle, DeflectlerpSpeed);
        // Debug.Log("Tipsaidsoftdeflect");
        Debug.Log("PDeflectSoft");

    }
}
