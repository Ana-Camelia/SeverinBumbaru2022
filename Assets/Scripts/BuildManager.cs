using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;
	private GameObject turretToBuild;
	public GameObject musicTurret;
	public GameObject friendsTurret;
	public GameObject gamingTurret;
	public GameObject coffeeTurret;
	public GameObject sleepTurret;
	public GameObject timeMgtTurret;
	public GameObject sbTurret;
	//private TileScript selectedNode;

	void Awake() //singleton
	{
		if (instance != null)
		{
			return;
		}
		instance = this;
	}


	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.GetComponent<Turette>().cost; } }

	public void SelectNode(TileScript node) //nu permitem ca un tile sa aiba mai mult de o tureta pe el
	{
		turretToBuild = null;
	}

	public void SelectTurretToBuild(GameObject turret) //selectam tureta de construit
	{
		turretToBuild = turret;
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}
}
