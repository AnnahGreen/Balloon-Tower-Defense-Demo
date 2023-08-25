using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	// public variables
	public int numberToSpawn = 10;
	public int numberSpawned = 0;

	public GameObject[] spawnObjects; // what prefabs to spawn
	

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		StartCoroutine(MakeThingToSpawn());
	}
	

	IEnumerator MakeThingToSpawn ()
	{
		for (int i=0; i<numberToSpawn;i++)
        {
			Vector3 spawnPosition = this.gameObject.transform.position;


			// determine which object to spawn
			int objectToSpawn = Random.Range(0, spawnObjects.Length);

			// actually spawn the game object
			GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

			// make the parent the spawner so hierarchy doesn't get super messy
			spawnedObject.transform.parent = gameObject.transform;
			numberSpawned++;
			yield return new WaitForSeconds(0.5f);
			
		}


	}
}
