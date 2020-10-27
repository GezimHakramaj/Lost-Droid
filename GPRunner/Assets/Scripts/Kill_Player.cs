using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Player : MonoBehaviour
{
    public delegate void KillHandler();
    public static event KillHandler killPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
            killPlayer();
    }
}
