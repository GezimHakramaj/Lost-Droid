using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    public float rotationPower; // How fast obstacle will rotate

    Rigidbody rb;
    int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        direction = Random.Range(0, 2);
    }

    private void Update()
    {
        // Handles which direction they will rotate.
        if (direction == 0)
            rb.AddTorque(transform.up * rotationPower); 
        else if (direction == 1)
            rb.AddTorque(transform.right * rotationPower);
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Destroy the object when out of bounds.
        if (collider.tag == "OutOfBounds") 
            Destroy(transform.root.gameObject);
    }
}
