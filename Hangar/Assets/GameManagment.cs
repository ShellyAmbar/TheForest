using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour {
    public int Round = 1;
    public int ZombiesInRound = 10;
    public int ZombiesSpawnedInRound = 0;
    public float ZombiesSpawnedTimer = 0;
    public Transform[] ZombiesSpawnPoints;
    public GameObject ZombieEnemy;
    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ZombiesSpawnedInRound < ZombiesInRound)
        {
            if (ZombiesSpawnedTimer > 30)
            {
                SpawnZombie();
                ZombiesSpawnedTimer = 0;
            }
            else
            {
                ZombiesSpawnedTimer += Time.deltaTime;
            }
        }
    }
    public void SpawnZombie()
    {
        Vector3 RandomSpawnpoint = ZombiesSpawnPoints[Random.Range(0, ZombiesSpawnPoints.Length)].position;
        Instantiate(ZombieEnemy, RandomSpawnpoint, Quaternion.identity);
        ZombiesSpawnedInRound++;

    }
}
