﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float maxX, minX;
    public bool autoPlay = false;
    private Ball ball;

    void Start(){
        ball = GameObject.FindObjectOfType<Ball>();
        print (ball);
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
        
        
	}

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(8, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);

        this.transform.position = paddlePos;
    }

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(8, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);

        this.transform.position = paddlePos;
    }
}
