/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

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
		this.isTaken = true;
	}
}
