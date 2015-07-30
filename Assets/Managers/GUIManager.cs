using UnityEngine;

public class GUIManager : MonoBehaviour 
{
	public GameObject mainMenuPanel, gameHudPanel, gameOverPanel, highScorePanel, optionsPanel, gamePausedPanel;
	
	public UISlider gameVolume;
	
	//public UILabel scoreLabel, livesLabel;
	
	//private static GUIManager instance;

	// Use this for initialization
	void Start () 
	{
		//instance = this;
		
		GameEventManager.MainMenu += MainMenu;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		GameEventManager.HighScore += HighScore;
		GameEventManager.Options += Options;
		
		mainMenuPanel.SetActive(true);
		gameHudPanel.SetActive(false);
		gameOverPanel.SetActive(false);
		highScorePanel.SetActive(false);
		optionsPanel.SetActive(false);
		gamePausedPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(!gameStarted)
		{
#if UNITY_EDITOR
			if(Input.GetMouseButtonDown(0))
			{
					GameEventManager.TriggerGameStart();
			}
#endif
#if UNITY_IPHONE
			foreach (Touch touch in Input.touches)
			{
				if(touch.phase == TouchPhase.Began)
				{
					GameEventManager.TriggerGameStart();
				}
			}
#endif	
		}*/
	}
	
	public static void SetScore(int score)
	{
		//instance.scoreText.text = "Score: " + score;
		UILabel scoreLabel = GameObject.Find("Score Label").GetComponent<UILabel>();
		scoreLabel.text = "Score: " + score;
	}
	
	public static void SetLives(int lives)
	{
		//instance.livesText.text = "Lives: " + lives;
		UILabel livesLabel = GameObject.Find("Lives Label").GetComponent<UILabel>();
		livesLabel.text = "Lives: " + lives;
	}
	
	public static void SetHighScore()
	{
		//instance.livesText.text = "Lives: " + lives;
		int[] scores = PlayerPrefsX.GetIntArray("Highscores", 0, 10);
		
		UILabel hsLabel = GameObject.Find("High Score Label").GetComponent<UILabel>();
		
		hsLabel.text = "";
		
		for(int i = 9; i >= 0; i--)
		{
			hsLabel.text += "" + scores[i] + "\n";
		}
	}
	
	private void GameStart ()
	{
		mainMenuPanel.SetActive(false);
		gameHudPanel.SetActive(true);
		gameOverPanel.SetActive(false);
		highScorePanel.SetActive(false);
		optionsPanel.SetActive(false);
	}
	
	private void GameOver()
	{
		mainMenuPanel.SetActive(false);
		gameHudPanel.SetActive(true);
		gameOverPanel.SetActive(true);
		highScorePanel.SetActive(false);
		optionsPanel.SetActive(false);
	}
	
	private void MainMenu()
	{
		mainMenuPanel.SetActive(true);
		gameHudPanel.SetActive(false);
		gameOverPanel.SetActive(false);
		highScorePanel.SetActive(false);
		optionsPanel.SetActive(false);
	}
	
	private void HighScore()
	{
		mainMenuPanel.SetActive(false);
		gameHudPanel.SetActive(false);
		gameOverPanel.SetActive(false);
		highScorePanel.SetActive(true);
		optionsPanel.SetActive(false);
	}
	
	private void Options ()
	{
		gameVolume.value = AudioManager.volume;
		mainMenuPanel.SetActive(false);
		gameHudPanel.SetActive(false);
		gameOverPanel.SetActive(false);
		highScorePanel.SetActive(false);
		optionsPanel.SetActive(true);
	}
}
