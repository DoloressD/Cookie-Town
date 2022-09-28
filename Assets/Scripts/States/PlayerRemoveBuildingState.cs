/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public class PlayerRemoveBuildingState : PlayerState
{
	BuildingManager buildingManager;
	public PlayerRemoveBuildingState(GameManager gameManager, BuildingManager buildingManager):base(gameManager)
	{
		this.buildingManager = buildingManager;
	}
	public override void OnCancel()
	{
		this.gameManager.TransitionToState(this.gameManager.selectionState, null);
	}

	public override void OnInputPanHeld(Vector3 position)
	{
		return;
	}

	public override void OnInputPanUp()
	{
		return;
	}

	public override void OnInputPointerDown(Vector3 position)
	{
		this.buildingManager.RemoveBuildingAt(position);
	}

	public override void OnInputPointerHeld(Vector3 position)
	{
		return;
	}

	public override void OnInputPointerUp()
	{
		return;
	}
}
