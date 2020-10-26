using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool dead = false; // Track if our player is dead.

    Rigidbody rb;

    private void Awake() // Subcribing to killPlayer event.
    {
        Kill_Player.killPlayer += OnDeath;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.velocity = new Vector3(-2, this.transform.position.y, this.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow))) // D or ->
        {
            // Changes the velocity component on the player to move its x position to the left side.
            rb.velocity = new Vector3(2, this.transform.position.y, this.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow))) // S or down arrow (duck)
        {
            // Changes the velocity component on the player to move its y position down.
            rb.velocity = new Vector3(this.transform.position.y, -0.5f, this.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Space)) // if presses space (jump)
        {
            // Changes the velocity component on the player to move its y position up.
            rb.velocity = new Vector3(this.transform.position.y, 2, this.transform.position.z);
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
