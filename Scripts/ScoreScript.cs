using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    public int score;
    
    void Start()
    {
        score = 0;
        ScoreUpdate();
    }

    
    void Update()
    {
        
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        scoreText.text = "Score " + score;
    }

}// class
