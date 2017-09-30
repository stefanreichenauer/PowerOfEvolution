using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAttack : MonoBehaviour {

    public bool aggresive = false;


    bool clawClosed = true;

    public GameObject openClaw;
    public GameObject closedClaw;

    public float switchTime = 0.1f;
    float lastSwitchTime;

    // Use this for initialization
    void Start () {
        lastSwitchTime = Time.time;


    }
	
	// Update is called once per frame
	void Update () {
        if (aggresive && Time.time - lastSwitchTime > switchTime)
        {
            lastSwitchTime = Time.time;
            if (clawClosed)
            {
                openClaw.SetActive(true);
                closedClaw.SetActive(false);
                clawClosed = false;
            }
            else
            {
                openClaw.SetActive(false);
                closedClaw.SetActive(true);
                clawClosed = true;
            }
        }
	}
    
}
