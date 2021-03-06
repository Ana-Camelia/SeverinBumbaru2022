using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turette : MonoBehaviour
{
	private Transform target;
	//private Enemy targetEnemy;

	[Header("General")]

	public float range = 2f;
    public int cost = 10;

    [Header("Use Bullets")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform firePoint;


    [Header("Audios")]
    [SerializeField] AudioClip shootSound;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget() //calculam cel mai apropiat inamic in care sa tragem
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    void Update() //daca avem target, putem sa tragem
    {
        if (target == null) return;
        
        if (!bulletPrefab) return;
        CountDownAndShoot();

    }

    private void CountDownAndShoot()
    {
        fireCountdown -= Time.deltaTime;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }

    void Shoot() //instantiem sunet si bullet
    {
        AudioSource.PlayClipAtPoint(shootSound, firePoint.position, 0.75f);
        GameObject bulletGO = (GameObject)Instantiate(
                    bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
