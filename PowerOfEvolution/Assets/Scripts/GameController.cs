﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    void Start()
    {
        
    }


    public void LoadScene(int index)
    {
        
        SceneManager.LoadScene(index);
    }
}
