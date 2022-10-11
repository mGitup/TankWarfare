using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//属性
	public int moveSpeed = 3;
	private Vector3 bulletEulerAngle;
	
	

	//引用
	private SpriteRenderer sr;
	public Sprite[] tankSprite;//上 右 下 左
	public GameObject bulletPrefab;
	public GameObject explosionPrefab;


	private float timeVal = 0;
	private float timeValChangeDirection = 0;
	private float v = -1;
	private float h;

	// Use this for initialization
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		if(timeVal >= 2)
        {
			Attack();
        }
        else
        {
			timeVal += Time.deltaTime;
		}

		OnCollider2D(gameObject.GetComponent<Collider2D>());
	}

	void FixedUpdate()
	{
		Move();
		
	}


	void Attack()
	{
		
		Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.position + bulletEulerAngle));
		timeVal = 0;	
	}

	void Move()
	{
		if(timeValChangeDirection >= 3)
        {
			int num = Random.Range(0,9);
            if (num >= 6)
            {
				v = -1;
				h = 0;
            }
			else if (num <= 1)
            {
				v = 1;
				h = 0;
            }
			else if (num > 1 &&num <= 3)
			{
				v = 0;
				h = -1;
			}
			else if (num > 3 && num <= 5)
			{
				v = 0;
				h = 1;
			}
			timeValChangeDirection = 0;
        }
        else
        {
			timeValChangeDirection += Time.fixedDeltaTime;
		}


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

		if (v != 0)
		{
			return;
		}

		transform.Translate(Vector2.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

		if (h < 0)
		{
			sr.sprite = tankSprite[3];
			bulletEulerAngle = new Vector3(0, 0, 90);
		}
		else if (h > 0)

		{
			sr.sprite = tankSprite[1];
			bulletEulerAngle = new Vector3(0, 0, -90);
		}

	}

	void Die()
	{
		PlayerManager.Instance.playerScore++;

		Instantiate(explosionPrefab, transform.position, transform.rotation);

		Destroy(gameObject);
	}

	private void OnCollider2D(Collider2D collider)
    {
		if(collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Barrier")
        {
			timeValChangeDirection = 3;
		}
    }

}
