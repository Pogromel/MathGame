using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Asteroid1;
    [SerializeField] private GameObject Asteroid2;
    [SerializeField] private GameObject Asteroid3;

    [SerializeField] private float initialSpawnInterval = 20f;
    private float currentSpawnInterval;
    
    
    
    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(spawnAsteroid(Asteroid1));
        StartCoroutine(spawnAsteroid(Asteroid2));
        StartCoroutine(spawnAsteroid(Asteroid3));
        StartCoroutine(AdjustSpawnInterval());
    }


    private IEnumerator spawnAsteroid(GameObject enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), Random.Range(6f, 9f), 0), Quaternion.identity);
        }
    }

    private IEnumerator AdjustSpawnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f); 
            if (currentSpawnInterval > 2)
            {
                currentSpawnInterval -= 2; 
                Debug.Log("Spawn interval decreased to: " + currentSpawnInterval + " seconds");
            }
        }
    }
    
}
