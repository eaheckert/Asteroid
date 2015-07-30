using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public AudioClip asteroidBlowUpSound, menuMusic, gameMusic;
	
	public static float volume;
	
	private bool menuMusicActive, gameMusicActive;
	
	void Start()
	{
		Debug.Log("Start AudioManager");
		GameEventManager.MainMenu += playMenuMusic;
		GameEventManager.DecreaseLives += PlayAsteroidBlownUp;
		GameEventManager.GameAudioUpdated += GameAudioVolumeUpdated;
		GameEventManager.GameStart += playGameMusic;
		
		audio.clip = menuMusic;
		audio.Play();
		menuMusicActive = true;
		gameMusicActive = false;
		
		if(PlayerPrefsX.GetBool("Has Game Been Played"))
		{
			Debug.Log("games first launch");
			PlayerPrefsX.SetBool("Has Game Been Played",true);
			PlayerPrefs.SetFloat("Game Volume",1);
		}
		
		volume = PlayerPrefs.GetFloat("Game Volume");
		audio.volume = volume;
		
	}
	
	private void playMenuMusic()
	{
		Debug.Log("Playing menu music");
		if(!menuMusicActive)
		{
			audio.clip = menuMusic;
			audio.Play();
			menuMusicActive = true;
			gameMusicActive = false;
		}
	}
	
	private void playGameMusic()
	{
		if(!gameMusicActive)
		{
			audio.clip = gameMusic;
			audio.Play();
			menuMusicActive = false;
			gameMusicActive = true;
		}
	}
	
	private void PlayAsteroidBlownUp()
	{
		audio.PlayOneShot(asteroidBlowUpSound);
	}
	
	private void GameAudioVolumeUpdated()
	{
		audio.volume = volume;
		PlayerPrefsX.GetIntArray("Highscores", 0, 10);
		PlayerPrefs.SetFloat("Game Volume",volume);
	}
}
