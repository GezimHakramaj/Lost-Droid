using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Player : MonoBehaviour
{
    public delegate void KillHandler();
    public static event KillHandler killPlayer;
    public bool val = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            killPlayer();
        
    }

}
