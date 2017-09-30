using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Player player;
    public float chargingSpeed = 1f;

    public bool chargingAttack = false;

    Vector3 startPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;


    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Start Pos: " + startPos);
       // Debug.Log("End Pos: " + endPos);


        if (player.HasSkill("Horns"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //ChargingAttack();
                chargingAttack = true;
                startPos = transform.position;
                endPos = transform.position + transform.forward * 10;
                
                startTime = Time.time;
                //journeyLength = Vector3.Distance(startPos, endPos);
            }
        }

        if (chargingAttack)
        {
            float distCovered = (Time.time - startTime) * speed;
            
            float fracJourney = distCovered * chargingSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);

            if (transform.position.Equals(endPos))
            {
           //     Debug.Log("Dist Pos: " + chargingAttack);
                chargingAttack = false;
            }
        }
    }


    void ChargingAttack()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + transform.forward * 100;

        //float vertical = chargingSpeed * Time.deltaTime;

        transform.position = Vector3.Lerp(startPos, endPos, 0.1f * Time.deltaTime);
        //transform.Translate(0, 0, vertical);
    }
}
