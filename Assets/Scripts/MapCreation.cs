using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {

	//用来装饰初始化地图所需物体的数组
	//老家，墙，障碍，出生效果，河流，草，空气墙, 出生效果2
	public GameObject[] item;

	//已经有东西的位置
	private List<Vector3> itemPositionList = new List<Vector3>();

	//产生敌人的时间间隔
	private float TimeCreateEnemy = 0;

	private void Awake()
    {
		InitMap();
	}

    private void InitMap()
    {
		//实例化老家
		CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
		CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
		CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);

		for (int i = -1; i < 2; i++)
		{
			CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);
		}

		//实例化外围墙
		for (int i = -11; i < 12; i++)
		{
			CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
		}
		for (int i = -11; i < 12; i++)
		{
			CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
		}
		for (int i = -9; i < 10; i++)
		{
			CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
		}
		for (int i = -9; i < 9; i++)
		{
			CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
		}

		//初始化玩家
		GameObject player = Instantiate(item[3], new Vector3(-3, -8, 0), Quaternion.identity);
		player.GetComponent<Born>().createPlayer = true;

		if (Option.isTwoPlayer)
		{
			GameObject player2 = Instantiate(item[7], new Vector3(3, -8, 0), Quaternion.identity);
			
		}

		//初始化敌人
		CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
		CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
		CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

		//方法二：
		InvokeRepeating("CreateEnemy", 4, 5);


		//实例化地图
		for (int i = 0; i < 6; i++)
		{
			CreateItem(item[1], new Vector3(-10, Random.Range(-8, 8), 0), Quaternion.identity);
			CreateItem(item[1], new Vector3(10, Random.Range(-8, 8), 0), Quaternion.identity);
		}

		for (int i = 0; i < 20; i++)
		{
			CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
		}

		for (int i = 0; i < 20; i++)
		{
			CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
			CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
			CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
			CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
		}
	}


	private void CreateItem(GameObject createGameObject, Vector3 createPosition,Quaternion createRotation)
    {
		GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
		itemGo.transform.SetParent(gameObject.transform);
		itemPositionList.Add(createPosition);
    }

	//产生随机位置
	private Vector3 CreateRandomPosition()
    {
		//最外面一圈不生成
        while (true)
        {
			Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);

            if (!HasThePosition(createPosition))
            {
			return createPosition;

            }
        }

    }

	//判断位置是否已占用
	private bool HasThePosition(Vector3 createPos)
    {
		foreach(Vector3 pos in itemPositionList)
        {
			if(createPos == pos)
            {
				return true;
            }
        }
		return false;
    }



    //方法一：
    //产生敌人
    //private Vector3 CreateEnemy()
    //   {
    //	int num = Random.Range(0, 3);
    //	Vector3 EnemyPos = new Vector3();
    //	if(num == 0)
    //       {
    //		EnemyPos = new Vector3(-10,8,0);
    //	}
    //	else if (num == 1)
    //	{
    //		EnemyPos = new Vector3(0, 8, 0);
    //       }
    //	else if(num == 2)

    //	{
    //		EnemyPos = new Vector3(10, 8, 0);
    //	}

    //	return EnemyPos;

    //}


    //void Update()
    //   {
    //	TimeCreateEnemy += Time.deltaTime;
    //	if(TimeCreateEnemy >= 4)
    //       {
    //		CreateItem(item[3], CreateEnemy(), Quaternion.identity);
    //		TimeCreateEnemy = 0;
    //	}
    //}

    //方法二：
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else if (num == 2)

        {
            EnemyPos = new Vector3(10, 8, 0);
        }

		CreateItem(item[3], EnemyPos, Quaternion.identity);

    }


}
