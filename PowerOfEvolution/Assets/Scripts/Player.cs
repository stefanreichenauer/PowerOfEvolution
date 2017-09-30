using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public int experiencePoints = 0;
    public int level = 1;
    public int skillPoints = 0;

    int levelThreshold = 100;

    List<Skill> skills = new List<Skill>();

    public UI ui;

    // Use this for initialization
    void Start () {
        skills.Add(new Skill(1, "Horns", null));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            takeDamage(10);
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

        ui.changeExperienceBar(levelThreshold, experiencePoints);
    }

	public void decreaseSkillPoints(int skillPnts)
	{
		if (skillPoints - skillPnts >= 0) {
			skillPoints -= skillPnts;
		}
		Debug.Log (skillPoints);
	}

    public void takeDamage(int healthLoss)
    {
        health = Mathf.Max(0, health - healthLoss);
        ui.changeHealthBar(100f, health);
        //Debug.Log("Enemy healthLoss: health - " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
    }


    public void AddSkill(Skill skill)
    {
        skills.Add(skill);
    }

    public bool HasSkill(string skillName)
    {
        foreach(Skill skill in skills)
        {
            if(skill.Name == skillName)
            {
                return true;
            }
        }

        return false;
    }
}
