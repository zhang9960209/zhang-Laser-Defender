using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfigSO;
    List<Transform> routeCheckPoint;
    int intCheckPointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfigSO = enemySpawner.GetCurrentWave();
        routeCheckPoint = waveConfigSO.GetCheckpoints();
        transform.position = routeCheckPoint[intCheckPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(intCheckPointIndex < routeCheckPoint.Count)
        {
            Vector3 enemyGoing = routeCheckPoint[intCheckPointIndex].position;
            float delta = waveConfigSO.GetEneSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, enemyGoing, delta);
            if(transform.position == enemyGoing)
            {
                intCheckPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
