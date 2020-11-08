using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float enginePower;
    public float tiltSpeed;
    public Material opt1;
    public Material opt2;

    float playerTilt = 0f;
    bool dead;
    Vector3 idle;    
    Rigidbody rb;


    private void Awake()
    {
        EventManager.killPlayer += OnDeath;
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("mat") == "opt1")
        {
            GetComponentsInChildren<MeshRenderer>()[0].material = opt1;
            GetComponentsInChildren<MeshRenderer>()[1].material = opt1;
        }
        else if (PlayerPrefs.GetString("mat") == "opt2")
        {
            GetComponentsInChildren<MeshRenderer>()[0].material = opt2;
            GetComponentsInChildren<MeshRenderer>()[1].material = opt2;
        }

        dead = false;
        idle = transform.rotation.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        checkTilt();

        if (dead)
            return;
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                MoveUp();
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                MoveDown();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                MoveLeft();
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                MoveRight();
        }
    }
  

    private void MoveUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + enginePower, rb.velocity.z);
    }

    private void MoveDown()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - enginePower, rb.velocity.z);
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector3(rb.velocity.x - enginePower, rb.velocity.y, rb.velocity.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 0.01f);
    }

    private void MoveRight()
    {
        rb.velocity = new Vector3(rb.velocity.x + enginePower, rb.velocity.y, rb.velocity.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 0.01f);
    }

    private void checkTilt()
    {
        if (rb.velocity.x > 0 || rb.velocity.y > 0)
        {
            if (playerTilt < 30f)
            {
                playerTilt += Time.deltaTime * tiltSpeed;
                transform.eulerAngles = new Vector3(playerTilt * 2, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }

    private void OnDeath()
    {
        dead = true;
    }

    private void OnDestroy()
    {
        EventManager.killPlayer -= OnDeath;
    }
}
