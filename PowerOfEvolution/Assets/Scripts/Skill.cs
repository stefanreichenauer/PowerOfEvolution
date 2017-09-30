using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {

	public int RequiredSkillPoints { get; set; }
	public string Name { get; set; }
	public Skill[] Requirements { get; set; }

	public Skill () 
	{
	}

	public Skill(int requiredSkillPoints, string name, Skill[] requirements) 
	{
		this.RequiredSkillPoints = requiredSkillPoints;
		this.Name = name;
		this.Requirements = requirements;
	}
}
