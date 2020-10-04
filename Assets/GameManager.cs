using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameStarted;

    public int startingEnemies;
    public int currentMaxEnemies;
    public int enemyIncreasePerWave;

    public GameObject enemyPrefab;
    public Transform[] enemySpawnpoints;
    public int currentlySpawned;
    public float spawnRate = 0.5f;
    float spawnTimer;

    public int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
