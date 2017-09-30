using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillActivation : MonoBehaviour {

	public Sprite skillUnavailable;
	public Sprite skillAvailable;
	public Sprite skillActive;

	public Button skillButton;

	public SkillController skillController;

	void Update () {
		string skillName = skillButton.GetComponentInChildren<Text> ().text.ToLower ();
		int available = skillController.skillAvailability (skillName);
		Sprite image = skillButton.GetComponent<Image> ().sprite;

		switch (available) {
		case -1:
			// unavailable
			changeButtonState(skillUnavailable, false);
			break;
		case 0:
			// available
			changeButtonState(skillAvailable, true);
			break;
		case 1:
			// activated
			changeButtonState(skillActive, false);
			changeLineState (skillName);
			break;
		}
	}

	void changeLineState(string skillName) {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("SkillTreeLine");
		foreach (GameObject object1 in objects) {
			if (object1.name.ToLower ().StartsWith (skillName.ToLower ())) {
				object1.GetComponent<Image> ().color = Color.yellow;
			}
		}
	}

	void changeButtonState(Sprite sprite, bool interact) {
		skillButton.GetComponent<Image> ().sprite = sprite;
		skillButton.interactable = interact;
	}
}
