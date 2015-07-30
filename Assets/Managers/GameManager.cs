using UnityEngine;
using System;

public class GameManager : MonoBehaviour 
{
	public int asteroidPointValue, startingLives;
	
	private int currentScore, currentLives;
	
	private bool gameActive;

	// Use this for initialization
	void Start () 
	{
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		GameEventManager.DecreaseLives += DecreaseLives;
		GameEventManager.IncreasePoints += IncreaseScore;
		
		gameActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	private void GameStart()
	{
		currentLives = startingLives;
		currentScore = 0;
		
		gameActive = true;
		
		GUIManager.SetScore(currentScore);
		GUIManager.SetLives(currentLives);
	}
	
	private void GameOver()
	{
		gameActive = false;
		
		
		//TO-DO: Finish adding in a high score system.
		int[] scores = PlayerPrefsX.GetIntArray("Highscores", 0, 10);
		
		Array.Sort(scores);
		
		if(currentScore > scores[0])
		{
			scores[0] = currentScore;
			
			Array.Sort(scores);
			
			PlayerPrefsX.SetIntArray("Highscores",scores);
		}
	}
	
	private void IncreaseScore()
	{
		if(gameActive)
		{
			currentScore += asteroidPointValue;
			
			GUIManager.SetScore(currentScore);
		}
	}
	
	private void DecreaseLives()
	{
		if(gameActive)
		{
			currentLives -= 1;
			
			if(currentLives <= 0)
			{
				gameActive = false;
			
				GUIManager.SetLives(0);
				
				GameEventManager.TriggerGameOver();
			}
			else
			{
				GUIManager.SetLives(currentLives);
			}
		}
	}
}
