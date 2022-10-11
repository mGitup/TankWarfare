using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour {

	private int choice = 1;
	public Transform posOne;
	public Transform posTwo;
	public static bool isTwoPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
			choice = 1;
			transform.position = posOne.position;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
			choice = 2;
			transform.position = posTwo.position;
        }

		if(choice == 1 && Input.GetKeyDown(KeyCode.Space))
        {
			isTwoPlayer = false;
			SceneManager.LoadScene(1);
        }
		else if(choice == 2 && Input.GetKeyDown(KeyCode.Space))

		{
			isTwoPlayer = true;
			SceneManager.LoadScene(2);
		}

	}
}
