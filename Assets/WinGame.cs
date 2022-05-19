using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<WaveSpawner>().spawnDone) return;
        if (FindObjectOfType<LevelManager>().isGameOver) return;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(enemies.Length);
        if (enemies.Length == 0)
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
    }
}
