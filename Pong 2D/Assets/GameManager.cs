using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    //Variables
    public int playerScore;
    public int enemyScore;

    // Use this for initialization
    void Start ()
    {
        InitGame();
	}

    private void InitGame()
    {
        this.playerScore = 0;
        this.enemyScore = 0;
    }
    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
