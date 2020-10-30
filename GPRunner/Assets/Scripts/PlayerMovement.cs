using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{

    bool dead = false; // Track if our player is dead.
    bool isGrounded = true; //Checks to see if player is grounded
    public Vector3 jump; 
    public float moveSpeed; //Increase this to increase horizontal distance covered for each keypress
    public float stopSpeed; //Stops all motion after a keypress after delay set to value of stopSpeed;
    public float jumpForce; //used to multiply with Y vector to determine how high player jumps
    public float fallMultiplier = 3.5f; //Value taken from Youtube Tutorial.
    private float delayTime;

    private float distToGround;
    private Score scoremanager;

    Rigidbody rb;
    CapsuleCollider cc;



    private void Awake() // Subcribing to killPlayer event.
    {
        Kill_Player.killPlayer += OnDeath;

        this.rb = GetComponent<Rigidbody>();
        this.cc = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
   
        jump = new Vector3(0, 1.0f, 0);
        distToGround = cc.bounds.extents.y;
        scoremanager = FindObjectOfType<Score>();

    }

    // Update is called once per frame
    void Update()
    {

        if (dead)
        {
            return;
        }

        if ((Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow))) && getGroundedVal()) // If presses A or <-
        {
            
                // Changes the velocity component on the player to move its x position to the left side.
                //rb.velocity = new Vector3(-2, this.transform.position.y*moveSpeed, this.transform.position.z);
                rb.velocity = new Vector3(-moveSpeed, 0, this.transform.localPosition.z);
                StartCoroutine(stopMove());
          

        }
        else if ((Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow))) && getGroundedVal()) // D or ->
        {
            // Changes the velocity component on the player to move its x position to the left side.
            rb.velocity = new Vector3(moveSpeed, 0, this.transform.localPosition.z);
            StartCoroutine(stopMove());

        }
        else if ((Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow))) && getGroundedVal()) // S or down arrow (duck)
        {
            // Changes the velocity component on the player to move its y position down.
            rb.velocity = new Vector3(this.transform.localPosition.y, -0.5f, this.transform.localPosition.z);
            StartCoroutine(stopMove());

        }
        else if (Input.GetKeyDown(KeyCode.Space) && getGroundedVal()) // if presses space (jump) and player is not already in air
        {

            // Changes the velocity component on the player to move its y position up.
            //rb.velocity = new Vector3(this.transform.position.y, 2, this.transform.position.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(stopMove());
            isGrounded = false;
        }

        //isGrounded = true;

        //Note: Default Gravity values can be set/altered within Unity. Edit > Project Settings... > Physics > Gravity
        //Gravity is enabled in Player inspector window

        if (rb.velocity.y < 0)
        {        
            rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; 
        }

        

    } //end Update

    //Stops movement after a certain amount of time. "stopSpeed" is the variable 
    //change "stopSpeed" depending on how fast you want the character to stop moving after a key press
    //Note: We can play around with moveSpeed + stopSpeed in order to creater cleaner and quicker movements or make it "lazier" depending on what we want
    //Good default numbers: moveSpeed = 8, stopSpeed = 0.2, jumpForce = 20 


    public bool getGroundedVal()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround +0.1f);
    }

    
    IEnumerator stopMove()
    {
        yield return new WaitForSeconds(stopSpeed);
        rb.velocity = new Vector3(0, 0, 0);

    }



    private void OnDeath()
    {        
        scoremanager.increaseScore = false;
        dead = true;
        GetComponentInChildren<BoxCollider>().enabled = false;

    }

    private void OnDestroy()
    {
        Kill_Player.killPlayer -= OnDeath;
        
    }

}
