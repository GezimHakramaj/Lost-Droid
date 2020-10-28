using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool dead = false; // Track if our player is dead.
    bool isGrounded = true; //Checks to see if player is grounded
    public Vector3 jump;
    public float moveSpeed;
    public float stopSpeed;
    public float jumpForce;

    private float delayTime;

    Rigidbody rb;

    private void Awake() // Subcribing to killPlayer event.
    {
        Kill_Player.killPlayer += OnDeath;
    }

    private void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 1.0f, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (dead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow))) // If presses A or <-
        {
            
                // Changes the velocity component on the player to move its x position to the left side.
                //rb.velocity = new Vector3(-2, this.transform.position.y*moveSpeed, this.transform.position.z);
                rb.velocity = new Vector3(-moveSpeed, 0, this.transform.localPosition.z);
                StartCoroutine(stopMove());
            

        }
        else if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow))) // D or ->
        {
            // Changes the velocity component on the player to move its x position to the left side.
            rb.velocity = new Vector3(moveSpeed, 0, this.transform.localPosition.z);
            StartCoroutine(stopMove());

        }
        else if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow))) // S or down arrow (duck)
        {
            // Changes the velocity component on the player to move its y position down.
            rb.velocity = new Vector3(this.transform.localPosition.y, -0.5f, this.transform.localPosition.z);
            StartCoroutine(stopMove());

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // if presses space (jump) and player is not already in air
        {

            // Changes the velocity component on the player to move its y position up.
            //rb.velocity = new Vector3(this.transform.position.y, 2, this.transform.position.z);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            StartCoroutine(stopMove());
            isGrounded = false;
        }

        isGrounded = true;

    } //end Update

    //Stops movement after a certain amount of time. "stopSpeed" is the variable 
    //change "stopSpeed" depending on how fast you want the character to stop moving after a key press
    //Note: We can play around with moveSpeed + stopSpeed in order to creater cleaner and quicker movements or make it "lazier" depending on what we want
    //Good default numbers: moveSpeed = 8, stopSpeed = 0.2, jumpForce = 20 

    IEnumerator stopMove()
    {
        yield return new WaitForSeconds(stopSpeed);
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void onFloorColCheck(Collision collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnDeath()
    {
        dead = true;
        GetComponentInChildren<BoxCollider>().enabled = false;
    }

    private void OnDestroy()
    {
        Kill_Player.killPlayer -= OnDeath;
    }

}
