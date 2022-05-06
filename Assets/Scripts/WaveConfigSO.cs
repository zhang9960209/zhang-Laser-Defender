using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")] 
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int intIndex)
    {
        return enemyPrefabs[intIndex];
    }

    public Transform GetStartingCheckpoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetCheckpoints()
    {
        List<Transform> routeCheckpoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            routeCheckpoints.Add(child);
        }
        return routeCheckpoints;
    }

    public float GetEneSpeed()
    {
        return movSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
