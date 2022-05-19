using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public GameObject musicTurret;
	public GameObject friendsTurret;
	public GameObject gamingTurret;
	public GameObject coffeeTurret;
	public GameObject sleepTurret;
	public GameObject timeMgtTurret;
	public GameObject sbTurret;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectMusicTurret()
	{
		buildManager.SelectTurretToBuild(musicTurret);
	}

	public void SelectFriendsTurret()
	{
		buildManager.SelectTurretToBuild(friendsTurret);
	}

	public void SelectGamingTurret()
	{
		buildManager.SelectTurretToBuild(gamingTurret);
	}

	public void SelectCoffeeTurret()
	{
		buildManager.SelectTurretToBuild(coffeeTurret);
	}

	public void SelectSleepTurret()
	{
		buildManager.SelectTurretToBuild(sleepTurret);
	}

	public void SelectTimeMgtTurret()
	{
		buildManager.SelectTurretToBuild(timeMgtTurret);
	}

	public void SelectSBTurret()
	{
		buildManager.SelectTurretToBuild(sbTurret);
	}
}
