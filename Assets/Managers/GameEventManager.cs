using UnityEngine;

public class GameEventManager : MonoBehaviour 
{
	
	public delegate void GameEvent();
	
	public static event GameEvent MainMenu, GameStart, GameOver, HighScore, Options, IncreasePoints, DecreaseLives, GameAudioUpdated;
	
	public static void TriggerMainMenu()
	{
		Debug.Log("TriggerMainMenu");
		if(GameOver != null)
		{
			MainMenu();
		}
	}
	
	public static void TriggerGameStart()
	{
		if(GameStart != null)
		{
			GameStart();
		}
	}
	
	public static void TriggerGameOver()
	{
		if(GameOver != null)
		{
			GameOver();
		}
	}
	
	public static void TriggerHighScore()
	{
		if(HighScore != null)
		{
			HighScore();
		}
	}
	
	public static void TriggerOptions()
	{
		if(Options != null)
		{
			Options();
		}
	}
	
	public static void TriggerIncreasePoints()
	{
		if(IncreasePoints != null)
		{
			IncreasePoints();
		}
	}
	
	public static void TriggerDecreaseLives()
	{
		if(DecreaseLives != null)
		{
			DecreaseLives();
		}
	}
	
	public static void TriggerGameAudioUpdated()
	{
		if(GameAudioUpdated != null)
		{
			GameAudioUpdated();
		}
	}
}
