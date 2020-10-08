using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int points = 0;

    public Text textPoints;

    Ball ball;
    Hole hole;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        hole = FindObjectOfType<Hole>();
    }

    void levelReset()
    {
        hole.randomize();
        ball.PrepareToLaunch();
        textPoints.text = points.ToString();
    }


    void Update()
    {
        if (ball.transform.position.x > 7) 
            levelReset();
    }

    public void ballHit(bool hit)
    {
        if (hit)
        {
            points++;
            GetComponent<AudioSource>().Play();
        }
        levelReset();
    }
}
