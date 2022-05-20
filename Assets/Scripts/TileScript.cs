using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
	public Color hoverColor;
	private Color startColor;
	public Color notEnoughMoneyColor;
	private SpriteRenderer rend;

	[HideInInspector]
	public GameObject turret;
	BuildManager buildManager;
	void Start()
	{
		rend = GetComponent<SpriteRenderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	//highlight pentru tile-uri

	void OnMouseEnter()
	{
		if (buildManager.GetTurretToBuild() == null) return;

		rend.material.color = buildManager.HasMoney ?
								hoverColor :
								notEnoughMoneyColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	//lansam procedura de constructie atunci cand dam click pe un tile fara tureta
	void OnMouseDown()
	{
		if (buildManager.GetTurretToBuild() == null) return;
		if (turret != null)	return;
		
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		
		if (PlayerStats.Money < turretToBuild.GetComponent<Turette>().cost)
			return;

		PlayerStats.Money -= turretToBuild.GetComponent<Turette>().cost;
		turret = (GameObject)Instantiate(turretToBuild, transform.position, Quaternion.identity);
	}

}
