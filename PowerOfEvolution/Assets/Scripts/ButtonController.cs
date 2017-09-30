using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	SkillController skillController;

	void Start() 
	{
		skillController = GameObject.FindGameObjectWithTag ("SkillController").GetComponent<SkillController> ();
	}

	public void OnClick(string skillName) {
		skillController.buySkill(skillName);
	}
}
