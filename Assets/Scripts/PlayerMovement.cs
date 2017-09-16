using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    public float jumpPower = 300f;
    private Rigidbody2D theRigidbody;

    public LayerMask groundLayer;
    public string HorizontalAxis;
    public string JumpAxis;

    public Transform leftCheck;
    public Transform rightCheck;

	// Use this for initialization
	void Start () {
        theRigidbody = GetComponent<Rigidbody2D>();
        leftCheck = transform.Find("LeftCheck");
        rightCheck = transform.Find("RightCheck");
	}
	
	// Update is called once per frame
	void Update () {
        float inX = Input.GetAxis(HorizontalAxis);
        theRigidbody.velocity = new Vector2(inX * speed, theRigidbody.velocity.y);

        bool jumping = Input.GetButtonDown(JumpAxis);
        bool grounded = Physics2D.OverlapCircle(leftCheck.position, 0.05f, groundLayer) || Physics2D.OverlapCircle(rightCheck.position, 0.05f, groundLayer);

        if(grounded && jumping) {
            theRigidbody.AddForce(new Vector2(0f, jumpPower));       
        }
	}
}
