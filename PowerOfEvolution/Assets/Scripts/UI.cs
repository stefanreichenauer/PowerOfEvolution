using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public RectTransform rect;
    public RectTransform experienceBar;

    // Use this for initialization
    void Start () {
        Debug.Log("Image Size:" + rect.rect.width);

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Image Size:" + rect.sizeDelta);

        if (Input.GetKeyDown(KeyCode.B))
        {
            experienceBar.sizeDelta = new Vector2(10,0);
            //changeExperienceBar(100,10);
        }

    }

    void changeExperienceBar(int maxValue, int newValue)
    {
        float newWidth = newValue / maxValue * experienceBar.rect.width;

        Mathf.Lerp(experienceBar.sizeDelta.x, newWidth, 0.2f * Time.deltaTime);
    }
}
