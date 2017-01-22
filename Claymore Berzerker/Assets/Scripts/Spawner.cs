using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject gameObjectToSpawn;
    public float SpawnTime = 5f;
    public float SpawnTimeOffset = 2f;

    private float randSpawnTime = 5f;
	// Use this for initialization
	void Start () {
        randSpawnTime = generateRandomSpawnTime();
        StartCoroutine(SpawnGameObject());
	}

    float generateRandomSpawnTime()
    {
        float randEnd = SpawnTime + Mathf.Abs(SpawnTimeOffset);
        return Random.Range(SpawnTimeOffset, randEnd);
    }

	
	// Update is called once per frame
	void Update () {
	    	
	}


    IEnumerator SpawnGameObject()
    {
        yield return new WaitForSeconds(randSpawnTime);
        randSpawnTime = generateRandomSpawnTime();
        StartCoroutine(SpawnGameObject());

        if (!GameControl.IsPaused)
        {
            var spawnedObject = Instantiate(gameObjectToSpawn);
            spawnedObject.transform.parent = gameObject.transform.parent;
            spawnedObject.transform.localPosition = gameObject.transform.localPosition;
            spawnedObject.transform.localScale = gameObject.transform.localScale;
        }
    }
}
