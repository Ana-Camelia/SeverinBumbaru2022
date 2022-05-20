using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;

	public float speed = 10f;

	public int damage = 50;

	public GameObject impactEffect;

	public void Seek(Transform _target)
	{
		target = _target;
	}

	void Update()
	{
		if (target == null)	//daca glontul n-are target, se autodistruge
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position; //calculam directia de deplasare
		float distanceThisFrame = speed * Time.deltaTime;	//viteza independenta de framerate

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		//delpasarea glontului pe directia si unghiul corespunzator
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    void HitTarget()
    {
		//efect de explozie
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

		//dam damage inamicului
        Enemy e = target.GetComponent<Enemy>();
        if(e != null)
            e.TakeDamage(damage);

		//distrugem glontul
        Destroy(gameObject);
    }
}
