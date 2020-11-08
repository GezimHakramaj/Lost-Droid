using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public GameObject text;
    public GameObject image;
    float timer = 0;
    int ctime = 0; 

    void Update()
    { 
        timer += Time.deltaTime;
        ctime = (int)(timer % 60f);
        if (ctime > 1)
            image.SetActive(true);
        if (ctime > 2)
            text.SetActive(true);
        if (ctime > 4 || Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Main Menu");
    }

    
}
