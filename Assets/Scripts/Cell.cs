/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System;
using UnityEngine;

//this class is to set the cell (grid cell) as taken when placed, to prevent overlap placement
public class Cell
{
    #region Variables
    GameObject structureModel = null;
    bool isTaken = false;

	public bool IsTaken { get => isTaken; }

	#endregion

	public void SetConstruction(GameObject structureModel)
	{
		if (structureModel == null)
			return;
		this.structureModel = structureModel;
		isTaken = true;
	}

	public GameObject GetStructure()
	{
		return structureModel;
	}

	public void RemoveStructure()
	{
		structureModel = null;
		isTaken = false;
	}
}
