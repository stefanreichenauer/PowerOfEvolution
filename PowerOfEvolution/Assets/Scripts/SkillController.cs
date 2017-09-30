using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour {
	
	Skill legs;
	Skill hand;
	Skill horns;
	Skill spikes;

	Skill[] AllSkills;

	public Player player;

	void Awake () 
	{
		legs = new Skill(2, "legs", new Skill[] {});
		hand = new Skill(4, "hand", new Skill[] { legs });
		horns = new Skill(8, "horns", new Skill[] { legs });
		spikes = new Skill(16, "spikes", new Skill[] { hand, horns });
		AllSkills = new Skill[] { legs, hand, horns, spikes };
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// 0 for available
	// -1 for unavailable
	// 1 for active
	public int skillAvailability(string skillName) {
		Skill skill = FindSkillByName (skillName);
		if (player.HasSkill (skill.Name)) {
			return 1;
		} else if (player.skillPoints > skill.RequiredSkillPoints && player.HasRequirements (skill)) {
			return 0;
		}

		return -1;
	}

	void changeLineState(string skillName) {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("SkillTreeLine");
		foreach (GameObject object1 in objects) {
			if (object1.name.ToLower ().StartsWith (skillName.ToLower ())) {
				object1.GetComponent<Image> ().color = Color.yellow;
			}
		}
	}

	public void buySkill(string skillName) 
	{
		Skill skill = FindSkillByName (skillName);
		player.decreaseSkillPoints (skill.RequiredSkillPoints);
		player.AddSkill (skill);
		changeLineState (skillName);
		// TODO: change model
		// TODO: skill specifics
	}

	public Skill FindSkillByName(string name) 
	{
		foreach (Skill skill in AllSkills) 
		{
			if (name.Trim().ToLower() == skill.Name.Trim().ToLower()) 
			{
				return skill;
			}
		}
		return null;
	}
}
