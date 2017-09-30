using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideSkillTree : MonoBehaviour {

	private Canvas skillTreeCanvas;

	// Use this for initialization
	void Start () {
		skillTreeCanvas = GetComponentInParent<Canvas> ();
		skillTreeCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.K) && skillTreeCanvas != null) {
			skillTreeCanvas.enabled = !skillTreeCanvas.enabled;
		}
	}
}
