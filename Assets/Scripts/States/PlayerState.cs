﻿/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public abstract class PlayerState
{
	protected GameManager gameManager;

	public PlayerState(GameManager gameManager)
	{
		this.gameManager = gameManager;
	}

	public abstract void OnInputPointerDown(Vector3 position);
	public abstract void OnInputPointerHeld(Vector3 position);
	public abstract void OnInputPointerUp();
	public abstract void OnInputPanHeld (Vector3 position);
	public abstract void OnInputPanUp();

	public virtual void EnterState(string variable)
	{

	}

	public abstract void OnCancel();
}
