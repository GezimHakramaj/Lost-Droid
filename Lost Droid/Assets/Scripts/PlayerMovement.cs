using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float enginePower;
    bool dead;
    Rigidbody rb;

    private void Awake()
    {
        Kill_Player.killPlayer += OnDeath;
        
    }

    private void Start()
    {
        dead = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (dead)
            return;
        else
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    rb.velocity = new Vector3(rb.velocity.x - enginePower, rb.velocity.y - enginePower, rb.velocity.z);
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    rb.velocity = new Vector3(rb.velocity.x + enginePower, rb.velocity.y - enginePower, rb.velocity.z);
                else
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - enginePower, rb.velocity.z);
            }
            else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    rb.velocity = new Vector3(rb.velocity.x - enginePower, rb.velocity.y + enginePower, rb.velocity.z);
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    rb.velocity = new Vector3(rb.velocity.x + enginePower, rb.velocity.y + enginePower, rb.velocity.z);
                else
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + enginePower, rb.velocity.z);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector3(rb.velocity.x - enginePower, rb.velocity.y, rb.velocity.z);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector3(rb.velocity.x + enginePower, rb.velocity.y, rb.velocity.z);
            }
        }
    }

    private void OnDeath()
    {
        dead = true;
    }

    private void OnDestroy()
    {
        Kill_Player.killPlayer -= OnDeath;
    }
}
