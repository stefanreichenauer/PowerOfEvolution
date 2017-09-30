using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    
    public Slider expSlider;
    public Slider healthSlider;

    public Text levelText;
    public GameObject skillMessage;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
       // Debug.Log("Image Size:" + rect.sizeDelta);
        if (Input.GetKeyDown(KeyCode.B))
        {
            changeExperienceBar(100,10);
        }

    }

    public void changeExperienceBar(float maxValue, float newValue)
    {        
        float newWidth = newValue / maxValue;

        expSlider.value = newWidth;
    }

    public void changeHealthBar(float maxValue, float newValue)
    {
        float newWidth = newValue / maxValue;

        healthSlider.value = newWidth;
    }

    public void changeLevelText(int level)
    {
        levelText.text = "Level: " + level;
    }

    public void toggleSkillMessage(bool showMessage)
    {
        skillMessage.SetActive(showMessage);
    }
}
