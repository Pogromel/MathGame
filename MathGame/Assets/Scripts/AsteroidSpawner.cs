using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Asteroid1;
    [SerializeField] private GameObject Asteroid2;
    [SerializeField] private GameObject Asteroid3;


    [SerializeField] private float SpawnInterval = 5f;
    
    
    
    void Start()
    {
        
        StartCoroutine(spawnAsteroid(SpawnInterval, Asteroid1));
        StartCoroutine(spawnAsteroid(SpawnInterval, Asteroid2));
        StartCoroutine(spawnAsteroid(SpawnInterval, Asteroid3));
    }


    private IEnumerator spawnAsteroid(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), Random.Range(6f, 9f), 0),
            Quaternion.identity);
        StartCoroutine(spawnAsteroid(interval, enemy));
    }
}
