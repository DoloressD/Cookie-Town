/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState
{
	PlacementManager placementManager;
	GridStructure grid;
	public PlayerBuildingSingleStructureState(GameManager gameManager,
											PlacementManager placementManager,
											GridStructure grid) : base(gameManager)
	{
		this.placementManager = placementManager;
		this.grid = grid;
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
		Vector3 gridPosition = grid.CalculateGridPosition(position);
		if (!grid.IsCellTaken(gridPosition))
		{
			placementManager.CreateBuilding(gridPosition, grid);
		}
	}

	public override void OnInputPointerHeld(Vector3 position)
	{
		return;
	}

	public override void OnInputPointerUp()
	{
		return;
	}

	public override void OnCancel()
	{
		this.gameManager.TransitionToState(this.gameManager.selectionState);
	}
}
