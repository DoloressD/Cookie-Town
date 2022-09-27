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
    public LayerMask inputMask;


    private BuildingManager buildingManager;
    private int cellSize = 3;
    //private bool buildingModeActive = false; //TODO: change to state pattern

    private PlayerState state;



    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;
    public PlayerRemoveBuildingState demolishState;

    public PlayerState State { get => state; }
    #endregion

    #region Unity Methods
    private void Awake()
	{
        buildingManager = new BuildingManager(cellSize, width, length, placementManager);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, buildingManager);
        demolishState = new PlayerRemoveBuildingState(this, buildingManager);
        state = selectionState;
        //state.EnterState();
#if (UNITY_EDITOR && TEST) || !(UNITY_IOS || UNITY_ANDRIOD)
        inputManager = gameObject.AddComponent<InputManager>();
#endif
#if (UNITY_IOS || UNITY_ANDRIOD)
#endif
    }
    void Start()
	{
		inputManager.mouseInputMask = inputMask;
		cameraMovement.SetCameraBounds(0, width, 0, length);

		//TODO: have inputManager change depending on platform
		//inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();

		AssignInputListeners();
		AssignUIListeners();
	}

	private void AssignUIListeners()
	{
		uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
		uiController.AddListenerOnCancelActionEvent(CancelAction);
		uiController.AddListenerOnDemolishlActionEvent(StartDemolishMode);
	}

	private void AssignInputListeners()
	{
		inputManager.AddListenerOnPointerDownEvent(HandleInput);
		inputManager.AddListenerOnPointerHeldEvent(HandleInputHeld);
		inputManager.AddListenerOnPointerSecondHeldEvent(HandleInputCameraPan);
		inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraStop);
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

    public void TransitionToState(PlayerState newState)
    {
        this.state = newState;
        this.state.EnterState();
    }

    private void StartPlacementMode()
	{
        TransitionToState(buildingSingleStructureState);
	}

    private void CancelAction()
	{
        state.OnCancel();
	}

    private void StartDemolishMode()
    {
        TransitionToState(demolishState);
    }
}
