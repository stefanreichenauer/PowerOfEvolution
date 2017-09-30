using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public SkillController skillController;

	void Start() 
	{
	}

	public void OnClick(string skillName) {
		skillController.buySkill(skillName);
	}
}
