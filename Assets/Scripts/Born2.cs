using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born2 : MonoBehaviour {

	public GameObject playerPrefab2;

		// Use this for initialization
	void Start()
	{
		Invoke("BornTank", 1);
		Destroy(gameObject, 1);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void BornTank()
	{
		
		Instantiate(playerPrefab2, transform.position, Quaternion.identity);
		
	}

}
