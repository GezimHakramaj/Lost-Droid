using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptions : MonoBehaviour
{
    public GameObject player;
    public Material opt1;
    public Material opt2;
    // Start is called before the first frame update
    void Update()
    {
        if (PlayerPrefs.GetString("mat") == "opt1")
        {
            player.GetComponentsInChildren<MeshRenderer>()[0].material = opt1;
            player.GetComponentsInChildren<MeshRenderer>()[1].material = opt1;
        }
        else if (PlayerPrefs.GetString("mat") == "opt2")
        {
            player.GetComponentsInChildren<MeshRenderer>()[0].material = opt2;
            player.GetComponentsInChildren<MeshRenderer>()[1].material = opt2;
        }
    }
    public void OnClick()
    {
        if (name == "Option 1")
            PlayerPrefs.SetString("mat", "opt1");
        else if (name == "Option 2")
            PlayerPrefs.SetString("mat", "opt2");
    }

}
