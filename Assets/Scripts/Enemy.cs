using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum SpawnState
    {
        Spawning,
        Waiting
    }

    private SpawnState CurrentState = SpawnState.Waiting;

    public float Health = 50f;
    public float Damage = 10f;
    public float EnemySpeed = 10f;

    public GameObject AirCraftEnemyPrefab;

    public GameObject[] SpawnLocations = new GameObject[4];

    private float WaveTimer = 10f;
    private float WaveLevel = 0;

    public float TimeBetweenWaves = 5f;
    public float WaveCountDown;

    private void Start()
    {
        WaveCountDown = TimeBetweenWaves;
    }

    private void Update()
    {
        if (WaveCountDown <= 0f)
        {
            if (CurrentState != SpawnState.Spawning)
            {
                //Start spawning a wave
                StartCoroutine(SpawnWave());
            }
        }
        else
        {
            WaveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {
        CurrentState = SpawnState.Spawning;
        //Spawn
        for (int i = 0; i < SpawnLocations.Length; i++)
        {
            SpawnEnemy(i);
        }
        WaveCountDown = TimeBetweenWaves;

        yield return new WaitForSeconds(WaveTimer);
        
        CurrentState = SpawnState.Waiting;

        yield break;
    }
   

    private void SpawnEnemy(int location)
    {
        //SpawnEnemy
        Instantiate(AirCraftEnemyPrefab, SpawnLocations[location].transform.position, Quaternion.identity );
    }
}
