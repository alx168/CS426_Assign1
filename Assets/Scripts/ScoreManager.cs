using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    public void add(){
    	score++;
    }
    public int getScore(){
    	return score;
    }
    public void setText(String text){
    	scoreDisplay.text = text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
