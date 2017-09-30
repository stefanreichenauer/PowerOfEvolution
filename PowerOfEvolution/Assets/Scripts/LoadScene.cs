using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadSceneByIndex(int scene) {
		SceneManager.LoadScene(scene);
	}

	public void OkOnClick() {
		Canvas canvas = GetComponentInParent<Canvas> ();
		canvas.enabled = !canvas.enabled;
	}
}
