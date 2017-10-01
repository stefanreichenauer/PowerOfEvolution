using UnityEngine;
using System.Collections;

public class BackMusicController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log(Application.loadedLevel);
        if (Application.loadedLevel == 2)
        {
            FindObjectOfType<AudioManager>().Play("splash_wave");
            FindObjectOfType<AudioManager>().Play("battle");
        }
        if (Application.loadedLevel == 1)
        {
            FindObjectOfType<AudioManager>().Play("track1");
        }
        if (Application.loadedLevel == 0)
        {
            FindObjectOfType<AudioManager>().Play("track2");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}