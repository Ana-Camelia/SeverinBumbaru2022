using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
	private float speed;
	[SerializeField] private float health = 50f;
	[SerializeField] private int score = 50;
	private bool isDead = false;

	private Transform target;
	[SerializeField] private float movementRandomFactor = 0.3f;
	[SerializeField] private Vector3 randomOffset;
	[SerializeField] private int waypointIndex = 0;
	WaveConfig waveConfig;

	//[SerializeField] AudioClip hitSound;

	void Start()
    {
		//preluam viteza din caracteristicile wave-ului
		speed = waveConfig.GetEnemySpeed() * waveConfig.GetSpeedRandomFactor();
		target = Waypoints.waypoints[waypointIndex];
		//deplasam inamicul cu o traiectorie cu factor de randomizare
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
        if(waypointIndex < Waypoints.waypoints.Length) //daca mai avem waypoint-uri de parcurs, ne deplasam catre urmatorul
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
		else //daca nu, inseamna ca am ajuns la final, ne autodistrugem si player-ul este invins
        {
			//Debug.Log("Finish");
			Die();
			FindObjectOfType<LevelManager>().isGameOver = true;
		}
    }


    public void TakeDamage(float amount)
	{	
		//AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, 0.3f);
		health -= amount;
		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		
		isDead = true;
		PlayerStats.Money += score;
		Destroy(gameObject);
	}
}
