using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Zombie zombiePrefab;
    public Transform[] spawnPoints;

    Sequencer s;

    public int maxSpawnedZombies;
    int currentSpawnedZombies;

    public BandMember[] bandMembers;
    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<Sequencer>();
        s.onNewNote.AddListener(SpawnZombie);
    }

    void SpawnZombie()
    {
        maxSpawnedZombies = Mathf.CeilToInt(s.currentActiveNotes/2);
        if (currentSpawnedZombies < maxSpawnedZombies)
        {
            Transform zombieSpawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Zombie z = Instantiate(zombiePrefab.gameObject, zombieSpawnpoint.position, zombieSpawnpoint.rotation).GetComponent<Zombie>();
            z.layer = Random.Range(0, 4);
            z.target = bandMembers[Random.Range(0, bandMembers.Length)].transform;
            //z.onCure.AddListener(DecreaseCurrentlySpawned);
            currentSpawnedZombies++;
        }
    }

    public void DecreaseCurrentlySpawned()
    {
        currentSpawnedZombies--;
    }

    void IncreaseMaxSpawned()
    {
        maxSpawnedZombies++;
    }
}
