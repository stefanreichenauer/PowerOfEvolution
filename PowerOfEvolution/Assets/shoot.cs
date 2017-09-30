using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
    public movement moveable;
    private int colldown = 0;
    // Use this for initialization
    void Start ()
    {
       
       //moveable.agressive=true;
    }
    void creatbullets()
    {
    //var bullet : Transform;
    //var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
    //bulletInstance.rigidbody.AddForce(transform.forward * 1000);

    }
// Update is called once per frame
    void Update ()
    {
		if (moveable.agressive==true)
        {
            if (colldown<0)
            {
            creatbullets();
            colldown = 60;
            }
            else
            {
            colldown = colldown - 1;
            }
        }

    }
}
