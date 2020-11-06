using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Death : MonoBehaviour
{
    public delegate void FallHandler();
    public static event FallHandler playerFall;
    public bool val = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            playerFall();

    }

}
