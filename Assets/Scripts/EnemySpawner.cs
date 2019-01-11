using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    [SerializeField] int startingWave = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = 0; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];

            yield return StartCoroutine(SpawnAllEnemiesInWaves(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWaves(WaveConfig waveConfig)
    {
        var totalNumberOfEnemies = waveConfig.GetNumberOfEnemies();
        for (int enemyCount = 0; enemyCount < totalNumberOfEnemies; enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
