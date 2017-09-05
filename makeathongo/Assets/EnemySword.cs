using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {



    public GameObject BackObjectToFollow;
    public GameObject FrontObjectToFollow;
    public GameObject backEnd;
    public GameObject frontEnd;


    // move speeds and positions of objects
    private Vector3 BackBasePos;
    private Vector3 FrontBasePos;

    public float BackZ;
    public float BackLerpSpeed;
    public float FrontZ;
    public float FrontlerpSpeed;
    //defense stuff
    public float MinDefSpeed;
    public float maxDefSpeed;
    private float DefMoveSpeed;
  
    private bool SetDefendSpeed;

    //attack stuff
    public float MinAttackTime;
    public float MaxAttackTime;
    private float AttackTime;

    private bool CalledAttack;
    private Animator MyAnim2;

    public int Cases  = 3;

    public GameObject Tip;



	// Use this for initialization
	void Start () {
        BackBasePos.z = BackZ;
        FrontBasePos.z = FrontZ;
        MyAnim2 = this.GetComponent<Animator>();
        Cases = 1;
        AttackTime = Random.Range(MinAttackTime, MaxAttackTime);
	}
	
	// Update is called once per frame
	void Update () {
        SwitchCase();

        AttackCooldown();
    }

    void SwitchCase()
    {
        switch (Cases)
        {
            case 1:
                MoveBack();
                MoveFront();
                break;

            case 2:
                Defend();
                break;

            case 3:
                Attack();
                break;

            default:
                Debug.Log("no case");
                break;
        }
    }
    void MoveBack()
    {
        BackBasePos = new Vector3(BackObjectToFollow.transform.position.x, BackObjectToFollow.transform.position.y, BackZ);
        backEnd.transform.position = Vector3.Lerp(backEnd.transform.position, BackBasePos, BackLerpSpeed);

       
    }
    void MoveFront()
    {
        FrontBasePos = new Vector3(FrontObjectToFollow.transform.position.x, FrontObjectToFollow.transform.position.y, FrontZ);
        frontEnd.transform.position = Vector3.Lerp(frontEnd.transform.position, FrontBasePos, FrontlerpSpeed);
    }

    void AttackCooldown()
    {
        AttackTime -= Time.deltaTime;
        if (AttackTime <= 0)
        {
            SwitchToAttack();
        }
    }

    public void SwitchToDefence()
    {
        SetDefendSpeed = false;
        Cases = 2;
    }

    public void SwitchToMove()
    {
        Cases = 1;
    }

    public void SwitchToAttack()
    {
        CalledAttack = false;
        Cases = 3;
    }

    void Defend()
    {
        if (!SetDefendSpeed)
        {
            DefMoveSpeed = Random.Range(MinDefSpeed, maxDefSpeed);

            SetDefendSpeed = true;
        }

        
            BackBasePos = new Vector3(Tip.transform.position.x, Tip.transform.position.y, BackZ);
            backEnd.transform.position = Vector3.Lerp(backEnd.transform.position, BackBasePos, DefMoveSpeed);

        
    }

    void Attack()
    {
        if (!CalledAttack)
        {
            MyAnim2.SetTrigger("EnemyLunge");
            AttackTime = Random.Range(MinAttackTime, MaxAttackTime);

            CalledAttack = true;
        }
    }
}
