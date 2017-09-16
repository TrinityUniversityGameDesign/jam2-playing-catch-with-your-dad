using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour {
    private float yValue;

	// Use this for initialization
	void Start () {
        yValue = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
	}
}
