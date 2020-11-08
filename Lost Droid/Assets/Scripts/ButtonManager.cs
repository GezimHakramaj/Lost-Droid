using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void SwitchScene()
    {
        switch (this.name)
        {
            case ("Play Button"):
                SceneManager.LoadScene("Gameplay");
                break;
            case ("Quit Button"):
                SceneManager.LoadScene("Main Menu");
                break;
            case ("Restart Button"):
                SceneManager.LoadScene("Gameplay");
                this.gameObject.SetActive(false);
                break;
            case ("Quit MM Button"):
                Application.Quit();
                break;
        }
    }
}
