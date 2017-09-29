using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public int experiencePoints = 0;
    public int level = 1;
    public int skillPoints = 0;

    int levelThreshold = 100;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            increaseExperiencePoints(10);
        }
       // Debug.Log("Test: exp: " + experiencePoints);
       // Debug.Log("Test: level: " + level);
    }

    public void increaseExperiencePoints(int expPoints)
    {
        experiencePoints += expPoints;

        if(experiencePoints >= levelThreshold)
        {
            experiencePoints -= levelThreshold;
            levelThreshold = (level + 1) * 100;
            skillPoints++;
            level++;
        }
    }
}
