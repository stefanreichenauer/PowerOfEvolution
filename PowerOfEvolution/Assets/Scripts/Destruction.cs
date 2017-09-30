using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    public GameObject exp;
    public GameObject sticks;
    public GameObject parent;
    public bool destroyed = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (destroyed)
        {
            GameObject explosion = Instantiate(exp, transform);
            GameObject stick = Instantiate(sticks, transform);

            GameObject stick2 = Instantiate(sticks, transform);
            
            stick2.transform.Translate(new Vector3(8, 0, 0));
            stick2.transform.Rotate(new Vector3(0, 0, 40));



            destroyed = false;
            
            //Destroy(gameObject);
            //DestroyShip();
        }
    }

    IEnumerator DestroyShip()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
