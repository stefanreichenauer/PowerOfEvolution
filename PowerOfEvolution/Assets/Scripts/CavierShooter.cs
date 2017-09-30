using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavierShooter : MonoBehaviour {

    public GameObject cavierPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 newPos = gameObject.transform.position + gameObject.transform.forward;
             newPos.y += 3;

            GameObject cavierBullet = Instantiate(cavierPrefab, newPos, transform.rotation);
            cavierBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1000);

        }
		
	}

}
