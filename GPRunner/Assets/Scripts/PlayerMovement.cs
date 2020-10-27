using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;  //public variables to control speed
    public float jumpSpeed;  //public variables to control speed
    float left_right; //Used for left & right movement
    float up; //Used for jump
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Left to Right movement
        //'A' key makes player go left
        //'D' key makes player go right
        //We use Time.deltaTime so that the character moves per seconds and not frames which makes it look smoother

        left_right = Input.GetAxis("Horizontal") * moveSpeed;
        this.transform.Translate(left_right*Time.deltaTime, 0, 0);  //the format is (x, y, z) so we change the x variable here for horizontal movement

        //Up Movement
        //'W' key makes player jump
        //We use Time.delaTime so that the character moves per seconds and not frames which makes it look smoother

        up = Input.GetAxis("Jump") * jumpSpeed; 
        this.transform.Translate(0, up * Time.deltaTime, 0); //moves our playerobject up on the Y Axis.



    }
}
