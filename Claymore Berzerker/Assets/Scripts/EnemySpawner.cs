using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject gameObjectToSpawn;
    public float SpawnTime = 5f;
    public float SpawnTimeOffset = 2f;

    private float randSpawnTime = 5f;
    public int CountDown = 10;
	// Use this for initialization
	void Start () {
        randSpawnTime = generateRandomSpawnTime();
        StartCoroutine(SpawnGameObject());
	}

    float generateRandomSpawnTime()
    {
        float randStart = SpawnTime - Mathf.Abs(SpawnTimeOffset);
        float randEnd = SpawnTime + Mathf.Abs(SpawnTimeOffset);
        return Random.Range(randStart , randEnd);
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
            CountDown--;
            var spawnedObject = Instantiate(gameObjectToSpawn);
            spawnedObject.transform.parent = gameObject.transform.parent;
            spawnedObject.transform.localPosition = gameObject.transform.localPosition;
            spawnedObject.transform.localScale = gameObject.transform.localScale;
            if (CountDown < 0)
            {
                if (Random.Range(0, 5) >= 4)
                {
                    SpawnBuddy(spawnedObject);
                }
                else if (Random.Range(0, 10) >= 9)
                {
                    SpawnBuddy(spawnedObject);
                    SpawnBuddy(spawnedObject, false);
                }
            }
        }
    }

    void SpawnBuddy(GameObject mainEnemy, bool below = true)
    {
        var spawnedObject = Instantiate(gameObjectToSpawn);
        spawnedObject.GetComponent<EnemyLogic>().Speed = mainEnemy.GetComponent<EnemyLogic>().Speed;
        spawnedObject.transform.parent = mainEnemy.transform.parent;
        var lp = gameObject.transform.localPosition;
        if (below)
        {
            var posX = Random.Range(0.1f, 0.2f);
            spawnedObject.transform.localPosition = new Vector3(lp.x + posX, lp.y - 0.015f, lp.z - 0.1f); ;
        }
        else
        {
            var posX = Random.Range(0.1f, 0.2f);
            spawnedObject.transform.localPosition = new Vector3(lp.x + posX, lp.y + 0.015f, lp.z + 0.1f); ;
        }
        spawnedObject.transform.localScale = gameObject.transform.localScale;
    }
}
