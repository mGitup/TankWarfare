using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int moveSpeed = 10;
	public bool isPlayerBullet;

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
			case "Tank":
                if (!isPlayerBullet)
                {
					collision.SendMessage("Die");
					Destroy(gameObject);
                }
				break;
				
			case "Barrier":
                if (isPlayerBullet)
                {
					collision.SendMessage("PlayAudio");
                }
				Destroy(gameObject);
				break;

			case "Heart":
				collision.SendMessage("Die");
				Destroy(gameObject);
				break;	
				
			case "Wall":
				Destroy(collision.gameObject);
				Instantiate(explosionPrefab, transform.position + new Vector3(0,0.5f,0), transform.rotation);
				Destroy(gameObject);
				break;
				
			case "Enemy":
				if (isPlayerBullet)
				{
					collision.SendMessage("Die");
					Destroy(gameObject);
				}				
				break;

		}
    }

}
