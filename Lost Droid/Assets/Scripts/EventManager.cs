using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void EventHandler();
    public static event EventHandler killPlayer;


    TimeManager tm;

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player" ) // If player hits an obstacle or out of bounds region.
        {
            killPlayer();
        }
        else if (collider.tag == "OutOfBounds") // Destroys all obstacles and powerups when hit the out of bounds are
        {
            Destroy(transform.root.gameObject);
        }
        else if (collider.tag == "Asteroid" && this.tag == "Player") //If player hits asteroid gameobjects then killplayer() is called
        {
            killPlayer();
        }
    }
}
