using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour 
{
	public GameObject prefab;
	
	public Vector3 currentPosition;
	public float minXPos;
	public float maxXPos;
	
	public float asteroidDelayTime;
	
	private GameObject asteroid, asteroidParent;
	private GameObject[] asteroidAR;
	private float lastAsteroidTime;
	private float currentTime;
	
	private bool gameStarted;

	// Use this for initialization
	void Start () 
	{
		asteroidParent = new GameObject();
		asteroidParent.name = "Run Time Asteroids";
		
		gameStarted = false;
		
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!gameStarted)
		{
			return;
		}
		
		currentTime += Time.deltaTime;
		if((currentTime - lastAsteroidTime) >= asteroidDelayTime)
		{
			SpawnAsteroid();
		}
		
#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
		{
			int layerMask = 1 << 8;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo, layerMask))
			{
				//Debug.Log(hitInfo.collider.gameObject.name);
				//hitInfo.collider.gameObject.GetComponent<Asteroids>().BlowUp();
				hitInfo.collider.transform.parent.gameObject.GetComponent<Asteroids>().BlowUp();
				GameEventManager.TriggerIncreasePoints();
			}
		}
#endif
#if UNITY_IPHONE
		foreach(Touch t in Input.touches)
		{
			if(t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
			{
				int layerMask = 1 << 8;
				Ray ray = Camera.main.ScreenPointToRay(t.position);
				RaycastHit hitInfo;
				if(Physics.Raycast(ray, out hitInfo,layerMask))
				{
					Debug.Log(hitInfo.collider.gameObject.name);
					//hitInfo.collider.gameObject.GetComponent<Asteroids>().BlowUp();
					hitInfo.collider.transform.parent.gameObject.GetComponent<Asteroids>().BlowUp();
					GameEventManager.TriggerIncreasePoints();
				}
			}
		}
#endif
	}
	
	private void GameStart()
	{
		gameStarted = true;
	}
	
	private void GameOver()
	{
		gameStarted = false;
	}
	
	private void SpawnAsteroid()
	{
		//Debug.Log("SpawnAsteroid");
		float xPos = Random.Range(minXPos,maxXPos);
		
		currentPosition.x = xPos;
		
		asteroid = (GameObject)Instantiate(prefab,currentPosition,transform.rotation);
		
		asteroid.transform.parent = asteroidParent.transform;
		
		lastAsteroidTime = currentTime;
		
		asteroid.GetComponent<Asteroids>().StartTailEmitter();
	}
}
