/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager
{
	private Action<Vector3> OnPointerDownHandler;
	private Action OnPointerUpHandler;
	private Action<Vector3> OnPointerHeldHandler;

	private Action OnPointerSecondUpHandler;
	private Action<Vector3> OnPointerSecondHeldHandler;

	private LayerMask mouseInputMask;

	LayerMask IInputManager.mouseInputMask { get => mouseInputMask; set => mouseInputMask = value; }


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		GetPointerPosition();
		GetPanningPosition();
	}

	private void GetPointerPosition()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			CallActionOnPointer((position) => OnPointerDownHandler?.Invoke(position));
		}

		if (Input.GetMouseButton(0))
		{
			CallActionOnPointer((position) => OnPointerHeldHandler?.Invoke(position));
		}

		if(Input.GetMouseButtonUp(0))
		{
			OnPointerUpHandler?.Invoke();
		}
	}

	private void CallActionOnPointer(Action<Vector3> action)
	{
		Vector3? position = GetMousePosition();
		if (position.HasValue)
		{
			action(position.Value);
			position = null;
		}
	}

	private Vector3? GetMousePosition()
	{
		Vector3? position = null;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
		{
			position = hit.point - transform.position;
		}

		return position;
	}

	private void GetPanningPosition()
	{
		if (Input.GetMouseButton(1))
		{
			var position = Input.mousePosition;
			OnPointerSecondHeldHandler?.Invoke(position);
		}
		if (Input.GetMouseButtonUp(1))
		{
			OnPointerSecondUpHandler?.Invoke();
		}
	}

	public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
	{
		OnPointerDownHandler += listener;
	}

	public void AddListenerOnPointerUpEvent(Action listener)
	{
		OnPointerUpHandler += listener;
	}

	public void AddListenerOnPointerHeldEvent(Action<Vector3> listener)
	{
		OnPointerHeldHandler += listener;
	}

	public void AddListenerOnPointerSecondUpEvent(Action listener)
	{
		OnPointerSecondUpHandler += listener;
	}

	public void AddListenerOnPointerSecondHeldEvent(Action<Vector3> listener)
	{
		OnPointerSecondHeldHandler += listener;
	}



	public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
	{
		OnPointerDownHandler -= listener;
	}

	public void RemoveListenerOnPointerUpEvent(Action listener)
	{
		OnPointerUpHandler -= listener;
	}

	public void RemoveListenerOnPointerHeldEvent(Action<Vector3> listener)
	{
		OnPointerHeldHandler -= listener;
	}

	public void RemoveListenerOnPointerSecondHeldEvent(Action<Vector3> listener)
	{
		OnPointerSecondHeldHandler -= listener;
	}

	public void RemoveListenerOnPointerSecondUpEvent(Action listener)
	{
		OnPointerSecondUpHandler -= listener;
	}




}
