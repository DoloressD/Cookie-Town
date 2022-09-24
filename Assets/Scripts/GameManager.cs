/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public PlacementManager placementManager;
    public IInputManager inputManager;
    public UIController uiController;
    public int width, length;
    public CameraMovement cameraMovement;
    private GridStructure grid;
    private int cellSize = 3;
    //private bool buildingModeActive = false; //TODO: change to state pattern

    private PlayerState state;



    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;

    public PlayerState State { get => state; }
    #endregion

    #region Unity Methods
    private void Awake()
	{
        grid = new GridStructure(cellSize, width, length);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, placementManager, grid);
        state = selectionState;
        state.EnterState();
	}
	void Start()
    {
        cameraMovement.SetCameraBounds(0, width, 0, length);
        //TODO: have inputManager change depending on platform
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();

        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerHeldEvent(HandleInputHeld);
        //inputManager.AddListenerOnPointerUpEvent();
        inputManager.AddListenerOnPointerSecondHeldEvent(HandleInputCameraPan);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraStop);
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancelActionEvent(CancelAction);
    }

    #endregion

    private void HandleInputHeld(Vector3 position)
    {
        state.OnInputPointerHeld(position);
    }

    private void HandleInput(Vector3 position)
    {
        state.OnInputPointerDown(position);
    }
    private void HandleInputCameraPan(Vector3 position)
    {
        state.OnInputPanHeld(position);
    }
    private void HandleInputCameraStop()
    {
        state.OnInputPanUp();
    }


    private void StartPlacementMode()
	{
        TransitionToState(buildingSingleStructureState);
	}

    private void CancelAction()
	{
        state.OnCancel();
	}

    public void TransitionToState(PlayerState newState)
	{
        this.state = newState;
        this.state.EnterState();
	}
}
