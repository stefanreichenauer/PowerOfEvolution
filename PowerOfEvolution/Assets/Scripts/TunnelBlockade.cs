using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelBlockade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestroyingBlockade()
    {

    }

    IEnumerator GoToLevelThree()
    {
        yield return new WaitForSeconds(1.0f);

    }
}
