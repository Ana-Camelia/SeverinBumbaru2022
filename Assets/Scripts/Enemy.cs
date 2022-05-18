using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	private float health = 50f;
	//private int score = 50;
	private bool isDead = false;

	private Transform target;
	[SerializeField] private float randomFactor = 0.3f;
	//[SerializeField] private Vector3 targetPos;
	[SerializeField] private Vector3 randomOffset;
	[SerializeField] private int waypointIndex = 0;

    void Start()
    {
		target = Waypoints.waypoints[waypointIndex];
		randomOffset = new Vector3(Random.Range(-randomFactor, randomFactor), Random.Range(-randomFactor, randomFactor), 0);
    }

    void Update()
    {
		Move();
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
				randomOffset = new Vector3(Random.Range(-randomFactor, randomFactor), Random.Range(-randomFactor, randomFactor), 0);
			}
		}
		else
        {
			//Debug.Log("Finish");
			Die();
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
