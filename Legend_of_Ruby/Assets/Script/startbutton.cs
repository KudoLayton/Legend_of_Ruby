﻿using UnityEngine;
using System.Collections;

public class startbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GameStart()
    {
        Application.LoadLevel("talk");
    }
}
