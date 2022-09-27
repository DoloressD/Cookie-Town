/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System;
using UnityEngine;

public interface IInputManager
{
	LayerMask mouseInputMask { get; set; }
	void AddListenerOnPointerDownEvent(Action<Vector3> listener);
	void AddListenerOnPointerUpEvent(Action listener);
	void AddListenerOnPointerHeldEvent(Action<Vector3> listener);
	void AddListenerOnPointerSecondHeldEvent(Action<Vector3> listener);
	void AddListenerOnPointerSecondUpEvent(Action listener);
	void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
	void RemoveListenerOnPointerUpEvent(Action listener);
	void RemoveListenerOnPointerHeldEvent(Action<Vector3> listener);
	void RemoveListenerOnPointerSecondHeldEvent(Action<Vector3> listener);
	void RemoveListenerOnPointerSecondUpEvent(Action listener);
}