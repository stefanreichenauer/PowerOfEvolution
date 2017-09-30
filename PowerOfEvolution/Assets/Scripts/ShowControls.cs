using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControls : MonoBehaviour {

	GameObject imageObject;

	void Awake() {
		imageObject = GameObject.FindGameObjectWithTag ("ControlsList");
		if (imageObject != null) {
			imageObject.GetComponent<Canvas> ().enabled = false;
		}
	}

	public void OkOnClick() {
		imageObject.GetComponent<Canvas> ().enabled = false;
	}

	public void ControlsOnClick() {
		imageObject.GetComponent<Canvas> ().enabled = true;
	}
}
