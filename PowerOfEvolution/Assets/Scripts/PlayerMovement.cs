using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    public float turningSpeed = 60;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
       // transform.Rotate(0, horizontal, 0);

        transform.InverseTransformDirection(0, horizontal, 0);
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
<<<<<<< HEAD
        //Debug.Log("Test PlayerMovement: " + vertical);
       // Debug.Log("Test PlayerMovement: " + vertical);
=======

>>>>>>> 1f76c6ec6c2bd26997457372cc4a989bc46adc26
        transform.Translate(0, 0, vertical);

        if(Input.GetAxis("Vertical") == 0)
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}