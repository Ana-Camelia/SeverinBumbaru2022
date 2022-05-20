using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sablon de wave

[CreateAssetMenu(menuName = "Enemy Wave")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float timeRandom = 2f;
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] float speedRandomFactor = 1f;
    [SerializeField] int enemyNumber = 5;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns * Random.Range(0.5f, timeRandom); }
    public float GetEnemySpeed() { return enemySpeed; }

    public float GetSpeedRandomFactor() { return Random.Range(1, speedRandomFactor); }
    public int GetEnemyNumber() { return enemyNumber; }
}
