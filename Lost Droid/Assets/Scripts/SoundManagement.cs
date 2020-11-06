using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{

    public static AudioClip moveSound, jumpSound, crashSound, fallSound;
    static AudioSource audioSrc = new AudioSource();

    // Use this for initialization
    void Start()
    {
        moveSound = Resources.Load<AudioClip>("move_sfx");
        jumpSound = Resources.Load<AudioClip>("jump_sfx");
        crashSound = Resources.Load<AudioClip>("crash_sfx");
        fallSound = Resources.Load<AudioClip>("fall_sfx");
        

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
            case "fallSound":
                audioSrc.PlayOneShot(fallSound);
                break;


        }
    }
}
