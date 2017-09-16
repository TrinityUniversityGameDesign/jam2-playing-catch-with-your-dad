using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallAttach : MonoBehaviour {

    private Rigidbody2D theRigidbody;
    private bool isDadCaught;
    private bool isSonCaught;
    private float ctr;
    public GameObject Dadpowerbar;
    public GameObject Sonpowerbar;
    public int score;
    public GameObject playerScore;
    public float timer;
    public GameObject timerText;
    private bool hitGround;
    private bool emergencyCatch;
    private AudioSource aud;
    public AudioClip scary;
    public AudioClip mainsong;
 
    // Use this for initialization
    void Start () {
        playerScore = GameObject.Find("Text");
        playerScore.GetComponent<Text>().text = "Dad Has Been Proud of You " + score + " Times"; 
        theRigidbody = GetComponent<Rigidbody2D>();
        timer = 5.0f;
        timerText = GameObject.Find("TimerText");
        hitGround = false;
        //HOW TO ACCESS SPECIFIC SONGS?
        aud = GetComponent<AudioSource>();
        aud.clip = mainsong;
        aud.Play();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isDadCaught == true && Input.GetButton("DadShoot")) {
            ctr++;
            Dadpowerbar.GetComponent<SpriteRenderer>().enabled = true;
            Dadpowerbar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green,Color.red,ctr/300f);

        }
        if (isSonCaught == true && Input.GetButton("SonShoot")) {
            ctr++;
            Sonpowerbar.GetComponent<SpriteRenderer>().enabled = true;
            Sonpowerbar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.red, ctr / 300f);
        } 

        if (Input.GetButtonUp("DadShoot") && isDadCaught == true) {
            isDadCaught = false;
            theRigidbody.simulated = true;
            transform.parent = null;
            theRigidbody.bodyType = RigidbodyType2D.Dynamic;
            theRigidbody.AddForce(new Vector2(ctr, ctr));
            Dadpowerbar.GetComponent<SpriteRenderer>().enabled = false;
            ctr = 0f;
        }
        if (Input.GetButtonUp("SonShoot") && isSonCaught == true) {
            isSonCaught = false;
            theRigidbody.simulated = true;
            transform.parent = null;
            theRigidbody.bodyType = RigidbodyType2D.Dynamic;
            theRigidbody.AddForce(new Vector2(-ctr, ctr));
            Sonpowerbar.GetComponent<SpriteRenderer>().enabled = false;
            ctr = 0f;
        }
        if(hitGround == true) {
            timer -= Time.deltaTime;
            timerText.GetComponent<Text>().text = timer.ToString();
            timerText.GetComponent<Text>().enabled = true;
            emergencyCatch = true;
           
        }

        if (timer <= 0.0f) {
            PlayerPrefs.SetFloat("finalscore", score);
            SceneManager.LoadScene("EndScene");
        }
    }
   
    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.tag == "DadMitt") {          
            transform.parent = other.gameObject.transform;
            theRigidbody.bodyType = RigidbodyType2D.Kinematic;
            theRigidbody.simulated = false;
            theRigidbody.velocity = Vector2.zero;
            isDadCaught = true;
            score += 1;
            playerScore.GetComponent<Text>().text = "Dad Has Been Proud of You " + score + " Times";
        }
        if (other.collider.gameObject.tag == "SonMitt")
        {
            transform.parent = other.gameObject.transform;
            theRigidbody.bodyType = RigidbodyType2D.Kinematic;
            theRigidbody.simulated = false;
            theRigidbody.velocity = Vector2.zero;
            isSonCaught = true;
            score += 1;
            playerScore.GetComponent<Text>().text = "Dad Has Been Proud of You " + score + " Times";
        }
        if(other.collider.gameObject.layer == LayerMask.NameToLayer("groundLayer")) {
            timer -= Time.deltaTime;
            timerText.GetComponent<Text>().text = timer.ToString();
            timerText.GetComponent<Text>().enabled = true;
            hitGround = true;
            aud.Stop();
            aud.clip = scary;
            aud.Play();
    
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (emergencyCatch == true && other.gameObject.name == "SpecialColliderDad")
        {
            hitGround = false;
            timer = 5.0f;
            //HELP WITH LOCATION OF BALL 
            transform.position = new Vector3(other.gameObject.transform.parent.transform.position.x, other.gameObject.transform.parent.transform.position.y + 2, other.gameObject.transform.parent.transform.position.z) ;
            aud.Stop();
            aud.clip = mainsong;
            aud.Play();
            timerText.GetComponent<Text>().enabled = false;
        }
        if (emergencyCatch == true && other.gameObject.name == "SpecialColliderSon")
        {
            hitGround = false;
            timer = 5.0f;
            //HELP WITH LOCATION OF BALL 
            transform.position = new Vector3(other.gameObject.transform.parent.transform.position.x, other.gameObject.transform.parent.transform.position.y + 2, other.gameObject.transform.parent.transform.position.z);
            aud.Stop();
            aud.clip = mainsong;
            aud.Play();
            timerText.GetComponent<Text>().enabled = false;
        }
    }

}
