using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

	private Canvas pauseMenuCanvas;

	// Use this for initialization
	void Start () {
		pauseMenuCanvas = GetComponentInParent<Canvas> ();
		pauseMenuCanvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape) && pauseMenuCanvas != null) {
			pauseMenuCanvas.enabled = !pauseMenuCanvas.enabled;
		}
		Time.timeScale = pauseMenuCanvas.enabled ? 0.0f : 1.0f;
	}

	public void ContinueOnClick() {
		if (pauseMenuCanvas != null && pauseMenuCanvas.enabled) {
			pauseMenuCanvas.enabled = false;
		}
	}
}
