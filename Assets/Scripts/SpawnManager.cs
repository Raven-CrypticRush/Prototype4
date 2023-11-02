using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables

    public GameObject enemyPrefab;
    public float spawnRange = 9;

    //enemy spawning
    public int enemyCount;
    public int waveNumber = 1;

    //powerup spawning
    public GameObject powerUpPrefab;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        //enemy count
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 ) 
        {
            waveNumber++; SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }

        //destroy enemy if out of bounds
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
       for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }

}
