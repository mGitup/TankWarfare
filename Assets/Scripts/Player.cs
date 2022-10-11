﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//属性
	public int moveSpeed = 3;
	private Vector3 bulletEulerAngle;	
	private float defendTimeVal = 3;
	private bool isDefended = true;

	//引用
	private SpriteRenderer sr;
	public Sprite[] tankSprite;//上 右 下 左
	public GameObject bulletPrefab;
	public GameObject explosionPrefab;
	public GameObject defendEffectPrefab;
	public AudioSource moveAudio;
	public AudioClip[] tankAudio;

	
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isDefended)
        {
			defendEffectPrefab.SetActive(true);
			defendTimeVal -= Time.deltaTime;
			if(defendTimeVal <= 0)
            {
				isDefended = false;
				defendEffectPrefab.SetActive(false);
			}
        }

	}

    void FixedUpdate()
    {
        if (PlayerManager.Instance.isDefeat)
        {
			return;
        }

			Move();
			Attack();
        

	}


	void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.position + bulletEulerAngle));
			
        }
    }

	

	void Move()
    {
		
		float v = Input.GetAxis("Player1_Vertical");
		transform.Translate(Vector2.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

		if (v < 0)
		{
			sr.sprite = tankSprite[2];
			bulletEulerAngle = new Vector3(0, 0, 180);
		}
		else if (v > 0)
		{
			sr.sprite = tankSprite[0];
			bulletEulerAngle = new Vector3(0, 0, 0);
		}

		//这音效太吵了
		//if (Mathf.Abs(v) > 0.05)
  //      {
		//	moveAudio.clip = tankAudio[1];
			
  //          if (!moveAudio.isPlaying)
  //          {
		//		moveAudio.Play();
  //          }
  //      }
		//else
		//{
		//	moveAudio.clip = tankAudio[0];

		//	if (!moveAudio.isPlaying)
		//	{
		//		moveAudio.Play();
		//	}
		//}


		if (v != 0)
        {
			return;
        }

		float h = Input.GetAxis("Player1_Horizontal");
		transform.Translate(Vector2.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

		if (h < 0)
		{
			sr.sprite = tankSprite[3];
			bulletEulerAngle = new Vector3(0, 0, 90);
		}
		else if (h > 0)//要排除等于零 即不按下的状态

		{
			sr.sprite = tankSprite[1];
			bulletEulerAngle = new Vector3(0, 0, -90);
		}

		

	}

	


	void Die()
    {
        if (isDefended)
        {
			return;
        }

		Instantiate(explosionPrefab, transform.position, transform.rotation);

		Destroy(gameObject);

		PlayerManager.Instance.isDead = true;
    }
}
