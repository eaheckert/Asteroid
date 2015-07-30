using UnityEngine;
using System.Collections;

public class Asteroids : MonoBehaviour 
{
	public ParticleSystem airExplosion;
	public ParticleSystem explosion;
	public ParticleSystem tail;
	public GameObject touchCollider;
	
	private bool gameActive = false;

	// Use this for initialization
	void Start () 
	{
		//tail.enableEmission = false;
		GameEventManager.GameOver += GameOver;
		gameActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void OnCollisionEnter ()
	{
		//Debug.Log("OnCollisionEnter");
		rigidbody.renderer.enabled = false;
		rigidbody.Sleep();
		collider.enabled = false;
		renderer.enabled = false;
		tail.enableEmission = false;
		touchCollider.collider.enabled = false;
		
		explosion.Play();
		if(gameActive)
		{
			GameEventManager.TriggerDecreaseLives();
		}
	}
	
	public void StartTailEmitter ()
	{
		//Debug.Log("StartTailEmitter");
		//tail.enableEmission = true;
		tail.Play();
	}
	
	public void BlowUp()
	{
		rigidbody.renderer.enabled = false;
		rigidbody.Sleep();
		collider.enabled = false;
		renderer.enabled = false;
		tail.enableEmission = false;
		touchCollider.collider.enabled = false;
		airExplosion.Play();
		GameEventManager.GameOver -= GameOver;
	}
	
	private void GameOver()
	{
		gameActive = false;
		if(gameObject == null)
		{
			//UnityEngine.Object.DestroyImmediate(gameObject);
			Destroy(gameObject);
		}
	}
}
