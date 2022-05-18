using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
	public Color hoverColor;
	public Color startColor;
	private SpriteRenderer rend;

	[HideInInspector]
	public GameObject turret;

	void Start()
	{
		rend = GetComponent<SpriteRenderer>();
		startColor = rend.material.color;
		Debug.Log(startColor.ToString());

		Debug.Log(hoverColor.ToString());
		//buildManager = BuildManager.instance;
	}

	void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	void OnMouseDown()
	{
		if (turret != null)
		{
			//buildManager.SelectNode(this);
			return;
		}

	}

}
