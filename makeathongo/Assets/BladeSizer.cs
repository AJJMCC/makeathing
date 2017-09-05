using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSizer : MonoBehaviour {
    public GameObject goStart;
    public GameObject goEnd;
    public float Scale;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetSize(goStart.transform.position, goEnd.transform.position);
	}

    void SetSize(Vector3 Start, Vector3 End)
    {
        Vector3 direction = End - Start;
        transform.localRotation = Quaternion.LookRotation(direction);
        transform.localScale = new Vector3(Scale, Scale, direction.magnitude);
        transform.localPosition = (Start + End) * 0.5f;
    }
}
