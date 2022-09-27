/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public class PlayerSelectionState : PlayerState
{
	CameraMovement cameraMovement;
	public PlayerSelectionState(GameManager gameManager, CameraMovement cameraMovement) : base(gameManager)
	{
		this.cameraMovement = cameraMovement;
	}
	public override void OnInputPanHeld(Vector3 panPosition)
	{
		cameraMovement.MoveCamera(panPosition);
	}

	public override void OnInputPanUp()
	{
		cameraMovement.StopCameraMovement();
	}

	public override void OnInputPointerDown(Vector3 position)
	{
		return;
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
		return;
	}
}
