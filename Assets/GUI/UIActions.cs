using UnityEngine;

public class UIActions: MonoBehaviour 
{
	public void StartGame ()
	{
		GameEventManager.TriggerGameStart();
	}
	
	public void MainMenu ()
	{
		GameEventManager.TriggerMainMenu();
	}
	
	public void HighScore ()
	{
		GameEventManager.TriggerHighScore();
		GUIManager.SetHighScore();
	}
	
	public void Options ()
	{
		GameEventManager.TriggerOptions();
	}
	
	public void AudioSliderUpdateValue(float newVal)
	{
		Debug.Log("Volume: "+ newVal);
	}
	
	public void AudioSliderUpdateValueNoVal()
	{
		
		Debug.Log("Volume: "+ UISlider.current.value);
		//audio.volume = UISlider.current.value;
		//GameEventManager.TriggerSetAudioVolume(UISlider.current.value);
		AudioManager.volume = UISlider.current.value;
		GameEventManager.TriggerGameAudioUpdated();
	}
}
