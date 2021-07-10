using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWaveIndex = 0;
    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        do
        {
           yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
        
    }
    private IEnumerator SpawnAllWaves()
    {
        for(int i = startingWaveIndex; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
           yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 1; i <= waveConfig.GetNumberOfEnemies(); i++)
        {
            GameObject Spawn = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaveWaypointsPrefab()[0].transform.position, Quaternion.identity);
            Spawn.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig); // sending the current wave config to our current Enemy Pathing;

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpwans());
        }
    }


}
