﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    void Update()
    {
        //if input A
        SceneManager.LoadScene("LevelScene");
    }
}
