using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttach : MonoBehaviour {

    private Rigidbody2D theRigidbody;
    private bool isCaught;
    private float ctr;

	// Use this for initialization
	void Start () {
        theRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isCaught = true && Input.GetButton("DadShoot")) {
            ctr++;
        }
        if(Input.GetButtonUp("DadShoot")) {
            theRigidbody.simulated = true;
            transform.parent = null;
            theRigidbody.bodyType = RigidbodyType2D.Dynamic;
            theRigidbody.AddForce(new Vector2(ctr, ctr));
        }
        if (Input.GetButtonUp("SonShoot"))
        {
            theRigidbody.simulated = true;
            transform.parent = null;
            theRigidbody.bodyType = RigidbodyType2D.Dynamic;
            theRigidbody.AddForce(new Vector2(-ctr, ctr));
        }
    }
   
    void OnCollisionEnter2D(Collision2D other) {
       // Debug.Log(other.collider.gameObject);
        if (other.collider.gameObject.tag == "DadMitt") {          
            transform.parent = other.gameObject.transform;
            theRigidbody.bodyType = RigidbodyType2D.Kinematic;
            theRigidbody.simulated = false;
            theRigidbody.velocity = Vector2.zero;
            isCaught = true;
        }
        if (other.collider.gameObject.tag == "SonMitt")
        {
            transform.parent = other.gameObject.transform;
            theRigidbody.bodyType = RigidbodyType2D.Kinematic;
            theRigidbody.simulated = false;
            theRigidbody.velocity = Vector2.zero;
            isCaught = true;
        }
        
    } 

}
