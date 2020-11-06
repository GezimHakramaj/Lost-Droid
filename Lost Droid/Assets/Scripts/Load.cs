using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    int ctime = 0; 

    void Update()
    { 
        timer += Time.deltaTime;
        ctime = (int)(timer % 60f);
        if (ctime > 1)
            SceneManager.LoadScene("Gameplay");
    }

    
}
