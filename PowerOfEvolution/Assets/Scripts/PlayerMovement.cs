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
=======
       // Debug.Log("Test PlayerMovement: " + vertical);
>>>>>>> d0c8388c34508e5d1e34fe2be51bf8afca30bf92
        transform.Translate(0, 0, vertical);

        if(Input.GetAxis("Vertical") == 0)
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}