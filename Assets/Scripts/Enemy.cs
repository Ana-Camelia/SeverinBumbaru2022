using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float health = 50f;
	//private int score = 50;
	private bool isDead = false;

	private Transform target;
	[SerializeField] private float movementRandomFactor = 0.3f;
	[SerializeField] private Vector3 randomOffset;
	[SerializeField] private int waypointIndex = 0;
	WaveConfig waveConfig;

	void Start()
    {
		speed = waveConfig.GetEnemySpeed() * waveConfig.GetSpeedRandomFactor();
		target = Waypoints.waypoints[waypointIndex];
		randomOffset = new Vector3(Random.Range(-movementRandomFactor, movementRandomFactor),
									Random.Range(-movementRandomFactor, movementRandomFactor), 0);
    }

    void Update()
    {
		Move();
	}

	public void SetWaveConfig(WaveConfig waveConfig)
	{
		this.waveConfig = waveConfig;
	}

	private void Move()
    {
        if(waypointIndex < Waypoints.waypoints.Length)
        {
			target = Waypoints.waypoints[waypointIndex];
			var movementOnFrame = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(
										transform.position,
										target.position + randomOffset,
										movementOnFrame);
			if (transform.position == target.position + randomOffset)
            {
				waypointIndex++;
				randomOffset = new Vector3(Random.Range(-movementRandomFactor, movementRandomFactor),
											Random.Range(-movementRandomFactor, movementRandomFactor), 0);
			}
		}
		else
        {
			//Debug.Log("Finish");
			Die();
			LevelManager.isGameOver = true;
		}
    }


    public void TakeDamage(float amount)
	{
		health -= amount;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		isDead = true;

		Destroy(gameObject);
	}
}
