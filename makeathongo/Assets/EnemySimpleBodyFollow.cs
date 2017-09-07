using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleBodyFollow : MonoBehaviour {

    public GameObject BackEndToFollow;
    public float lerpSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       Vector3 BackBasePos = new Vector3(BackEndToFollow.transform.position.x, BackEndToFollow.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, BackBasePos, lerpSpeed);
    }
}
