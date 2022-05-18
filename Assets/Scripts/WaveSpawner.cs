using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    //[SerializeField] bool looping = false;
    private float countdown = 5f;
    private float timeBetweenWaves = 30f;
    bool coroutineRunning = false;

    void Update()
    {
        countdown -= Time.deltaTime;
        if (coroutineRunning) return;
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnAllWaves());
            coroutineRunning = true;
        }
    }

    IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++) //parcurgem lista de wave-uri
        {
            var currentWave = waveConfigs[waveIndex];
            StartCoroutine(SpawnAllEnemiesInWave(currentWave)); 
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyIndex = 0; enemyIndex < waveConfig.GetEnemyNumber(); enemyIndex++) //lansam atatia inamici cati am indicat in waveConfig
        {
            //instantiem prefab-ul ales, la pozitia 0 din traiectorie, si il intoarcem la 180 de grade pentru a fi cu fata spre jucator
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                GameObject.Find("Start").transform.position,
                Quaternion.identity);

            var enemy = newEnemy.GetComponent<Enemy>();
            enemy.SetWaveConfig(waveConfig);
            //enemyPathing = newEnemy.GetComponent<EnemyPathing>();
            //enemyPathing.SetWaveConfig(waveConfig); //setam waveConfig-ul in codul de enemyPathing atasat fiecarui inamic
            //enemyPathing.SetWaypointOffset(offsetVector);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()); //asteptam un anumit timp pana la instantierea urmatorului inamic
        }
    }
}
