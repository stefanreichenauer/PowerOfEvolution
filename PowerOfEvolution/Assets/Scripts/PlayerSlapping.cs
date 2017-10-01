using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlapping : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyCrab")
        {
            collision.gameObject.GetComponent<EnemyCrab>().takeDamage(10);
        }

        if (collision.gameObject.tag == "Shell")
        {
            collision.gameObject.GetComponent<EnemyShell>().takeDamage(10);
        }
        

    }

}
