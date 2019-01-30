using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject board;
    public lerpMovement hoopMovement;
    public ScoreManager scoreManager;
    public Player player;
    public Canvas canvas;

    private bool instantiatedOnce;
    private bool instantiatedTwice;
    private lerpMovement lmScript;
    public Image[] ballImages;

    void Start()
    {
    	instantiatedOnce = false;
    	instantiatedTwice = false;
    	ballImages = canvas.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(scoreManager.getScore() == 1){
    		hoopMovement.lerpy = true;
    	}else if(scoreManager.getScore() == 2){
    		hoopMovement.lerpy = false;
    		hoopMovement.lerpx = true;
    	}else if(scoreManager.getScore() == 3){
    		hoopMovement.lerpy = true;
    		hoopMovement.lerpx = true;
    	}else if(scoreManager.getScore() == 4 && instantiatedOnce == false){
			GameObject prefabInstance = GameObject.Instantiate<GameObject>(board);
			lmScript = prefabInstance.GetComponent<lerpMovement>();
    		lmScript.lerpx = true;
    		lmScript.lerpy = true;
    		instantiatedOnce = true;
    	}else if (scoreManager.getScore() == 5 && instantiatedTwice == false){
			GameObject prefabInstance1 = Instantiate(board, new Vector3(-10,6,9),transform.rotation);
			lmScript = prefabInstance1.GetComponent<lerpMovement>();
    		lmScript.lerpx = true;
    		lmScript.lerpy = true;
    		lmScript.speed = 6f;
    		instantiatedTwice = true;
    	}

    	ballImages[player.getShotsLeft()].gameObject.SetActive(false);

        //gameover
        if(player.getShotsLeft() == 0 && scoreManager.getScore() != 5){
        	scoreManager.setText("Game Over!\nYou lost!");
        }else if(scoreManager.getScore() == 5){
        	scoreManager.setText("You Won!");
    	}else{
        	scoreManager.setText(String.Format("Score: {0}",scoreManager.getScore()));
        }
    }
}
