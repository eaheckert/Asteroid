using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour 
{
	
	public float timeAlive = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeAlive -= Time.deltaTime;
		if(timeAlive <= 0)
		{
			if(gameObject == null)
			{
				Destroy(gameObject);
			}
		}
	}
}
