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
            GameObject cavierBullet = Instantiate(cavierPrefab, gameObject.transform);
            cavierBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward);

        }
		
	}
}
