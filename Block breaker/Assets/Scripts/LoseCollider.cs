﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    void OnTriggerEnter2D (Collider2D trigger){
        print("trigger");
        levelManager.LoadLevel("lose");

        

    }

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }
    
    
}
