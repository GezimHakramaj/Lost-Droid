using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{

    public static AudioClip moveSound, jumpSound, crashSound, fallSound, flameSound, crash2Sound;
    static AudioSource audioSrc = new AudioSource();

    // Use this for initialization
    void Start()
    {
        //Delete one Crash sound when the preferred one is picked.

        moveSound = Resources.Load<AudioClip>("move_sfx");
        jumpSound = Resources.Load<AudioClip>("jump_sfx");
        crashSound = Resources.Load<AudioClip>("crash_sfx");
        crash2Sound = Resources.Load<AudioClip>("crash2_sfx");
        fallSound = Resources.Load<AudioClip>("fall_sfx");
        flameSound = Resources.Load<AudioClip>("flame_sfx");
        

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "moveSound":
                audioSrc.PlayOneShot(moveSound);
                break;
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "crashSound":
                audioSrc.PlayOneShot(crashSound);
                break;
            case "crash2Sound":
                audioSrc.PlayOneShot(crash2Sound);
                break;
            case "fallSound":
                audioSrc.PlayOneShot(fallSound);
                break;
            case "flameSound":
                audioSrc.clip = flameSound;
                audioSrc.loop = true;
                break;


        }
    }
}
