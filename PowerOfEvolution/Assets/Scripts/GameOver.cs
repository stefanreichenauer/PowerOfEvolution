using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private void Awake()
    {
        Destroy(GameObject.Find("PlayerController"));
        StartCoroutine("LoadMainMenu");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
    }

}
