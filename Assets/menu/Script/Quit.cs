﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{

    public void OnQuit()
    {
        Debug.Log("Bye !");
        Application.Quit();
    }
}
