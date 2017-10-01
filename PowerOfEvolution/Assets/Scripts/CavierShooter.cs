using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavierShooter : MonoBehaviour {

    public GameObject cavierPrefab;

    float lastShot;
    public float cavierCooldown = 1.5f;

    // Use this for initialization
    void Start () {

        lastShot = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

       // Debug.Log("CavierShooter: " + (Time.time - lastShot > cavierCooldown));
        if (Input.GetKeyDown(KeyCode.E) && (Time.time - lastShot > cavierCooldown))
        {
            lastShot = Time.time;
               Vector3 newPos = gameObject.transform.position + gameObject.transform.forward;
             newPos.y += 3;

            GameObject cavierBullet = Instantiate(cavierPrefab, newPos, transform.rotation);
            cavierBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1000);

        }
		
	}

}
