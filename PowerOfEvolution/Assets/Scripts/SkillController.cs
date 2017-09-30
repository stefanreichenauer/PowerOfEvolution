using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {
	
	Skill legs;
	Skill hand;
	Skill horns;
	Skill spikes;

	Skill[] AllSkills;

	public Player player;

	// Use this for initialization
	void Start () 
	{
		legs = new Skill(2, "legs", new Skill[] {});
		hand = new Skill(4, "hand1", new Skill[] { legs });
		horns = new Skill(8, "hand2", new Skill[] { legs });
		spikes = new Skill(16, "hand2", new Skill[] { legs, hand, horns });
		AllSkills = new Skill[] { legs, hand, horns, spikes };
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void buySkill(string skillName) 
	{
		Skill skill = FindSkillByName (skillName);
		player.decreaseSkillPoints (skill.RequiredSkillPoints);
		// change model
		// skill specifics
	}

	public Skill FindSkillByName(string name) 
	{
		foreach (Skill skill in  AllSkills) 
		{
			if (name == skill.Name) 
			{
				return skill;
			}
		}
		return null;
	}
}
