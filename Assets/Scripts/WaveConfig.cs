using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpwans = 0.5f;
    [SerializeField] float spawnRandomFactor;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float moveSpeed = 10f;



    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaveWaypointsPrefab()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        
        return waveWaypoints;
    }
    public float GetTimeBetweenSpwans() { return timeBetweenSpwans; }
    public float GetSpwanRandomFactor() { return spawnRandomFactor; }
    public float GetMoveSpeed() { return moveSpeed; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
}
