using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{


    //Player Sword
    public GameObject BackObjectToFollow;
    public GameObject FrontObjectToFollow;
    public GameObject PlayerBlade;

    public GameObject backEnd;
    public GameObject frontEnd;
    public GameObject EnBlade;

    //Deflect stuff
    private float EnX;
    private float EnY;

    public float DeflectlerpSpeed;

    private bool SetAngletValues;


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

    public bool Lunging;

    private bool CalledAttack;
    private Animator MyAnim2;

    //duble stuff

    public float MaxRandomAttackMod;
    public float DubleChance;

    public int Cases=6;

    public GameObject Tip;



    // Use this for initialization
    void Start()
    {
        BackBasePos.z = BackZ;
        FrontBasePos.z = FrontZ;
        MyAnim2 = this.GetComponent<Animator>();
        Cases = 1;
        AttackTime = Random.Range(MinAttackTime, MaxAttackTime);
    }

    // Update is called once per frame
    void Update()
    {
        backEnd.transform.rotation = EnBlade.transform.rotation;
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

            case 4:
                DeflectSoft();
                break;

            case 5:
                Deflecthard();
                break;

            case 6:
                Duble();
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



    public void SwitchToDefence()
    {
        SetDefendSpeed = false;
        Cases = 2;
    }

    public void SwitchToMove()
    {
        Cases = 1;
        SetAngletValues = false;
    }

    public void SwitchToAttack()
    {
        CalledAttack = false;
     if (DubleChance <=  Random.Range(0,MaxRandomAttackMod))
            Cases = 6;

     else
        Cases = 3;
    }

    public void SwitchToDeflectSoft()
    {
        if (Cases != 2)
        {
            Cases = 4;
            Invoke("SwitchToMove", 1);
        }
       
      
    }

    public void SwitchToDeflecthard()
    {
        if (Cases != 2)
        {
            Cases = 5;
            Invoke("SwitchToMove", 1);
        }
          
    }

    public void MovingBack()
    {
        Lunging = false;
    }

    void DeflectSoft()
    {
        if (!SetAngletValues)
        {
            EnX = EnBlade.transform.rotation.x;
            EnY = EnBlade.transform.rotation.y;
            Lunging = false;
            SetAngletValues = true;
        }

        Vector3 Angle = new Vector3((EnX * 2) + 180, (EnY * 2) + 180, backEnd.transform.rotation.z);
        backEnd.transform.eulerAngles = Vector3.Lerp(backEnd.transform.eulerAngles, Angle, DeflectlerpSpeed);
        Debug.Log("Tipsaidsoftdeflect");
    }

    void Deflecthard()
    {
        if (!SetAngletValues)
        {
            EnX = EnBlade.transform.rotation.x;
            EnY = EnBlade.transform.rotation.y;
            Lunging = false;

            SetAngletValues = true;
        }

        Vector3 Angle = new Vector3((EnX * 4) + 180, (EnY * 4) + 180, backEnd.transform.rotation.z);
        backEnd.transform.eulerAngles = Vector3.Lerp(backEnd.transform.eulerAngles, Angle, DeflectlerpSpeed * 2);
        Debug.Log("Tipsaidharddeflect");

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
            Lunging = true;
            MyAnim2.SetTrigger("EnemyLunge");
            AttackTime = Random.Range(MinAttackTime, MaxAttackTime);
            Debug.Log("Attacked");
            CalledAttack = true;
        }
    }
    public void MidDuble()
    {
        backEnd.transform.eulerAngles = new Vector3(backEnd.transform.rotation.x + Random.Range(1, 15), backEnd.transform.rotation.y + Random.Range(1, 15), backEnd.transform.rotation.z + Random.Range(1, 15));
    }

    void Duble()
    {
        if (!CalledAttack)
        {
            Lunging = true;
            MyAnim2.SetTrigger("EnemyDuble");
            AttackTime = Random.Range(MinAttackTime, MaxAttackTime);
            Debug.Log("Dubled");
            CalledAttack = true;
        }
    }

    void AttackCooldown()
    {
        AttackTime -= Time.deltaTime;
        if (AttackTime <= 0)
        {
            SwitchToAttack();
        }
    }



}
