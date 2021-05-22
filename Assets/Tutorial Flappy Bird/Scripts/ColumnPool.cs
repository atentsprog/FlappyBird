using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColumnPool : MonoBehaviour 
{
	public GameObject columnPrefab;									//The column game object.
	public int columnPoolSize = 5;									//How many columns to keep on standby.
	public float spawnRate = 3f;									//How quickly columns spawn.
	public float columnMin = -1f;									//Minimum y value of the column position.
	public float columnMax = 3.5f;									//Maximum y value of the column position.

	public  List<GameObject> columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;


	IEnumerator Start()
	{
		for(int i = 0; i < 5; i++)
		{
			columns.Add(Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity));
		}

		GameControl.instance.gameOver = false;
		while (GameControl.instance.gameOver == false)
		{
			float spawnYPosition = Random.Range(columnMin, columnMax);
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			
			
			currentColumn++;
			//최대 인덱스 크기 넘어가면 다시 첫번째 인덱스부터 위치 이동되도록 인덱스 0으로 수정
			if (currentColumn >= columns.Count)
			{
				currentColumn = 0;
			}

			yield return new WaitForSeconds(spawnRate);
		}
	}


	////This spawns columns as long as the game is not over.
	//void Update()
	//{
	//	timeSinceLastSpawned += Time.deltaTime;

	//	if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
	//	{	
	//		timeSinceLastSpawned = 0f;

	//		//Set a random y position for the column
	//		float spawnYPosition = Random.Range(columnMin, columnMax);

	//		//...then set the current column to that position.
	//		columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

	//		//Increase the value of currentColumn. If the new size is too big, set it back to zero
	//		currentColumn ++;

	//		if (currentColumn >= columnPoolSize) 
	//		{
	//			currentColumn = 0;
	//		}
	//	}
	//}
}