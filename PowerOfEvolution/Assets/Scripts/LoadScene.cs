using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	public void LoadSceneByIndex(int scene) {
		SceneManager.LoadScene(scene);
	}
}
