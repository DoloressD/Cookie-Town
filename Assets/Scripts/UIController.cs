/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Variables
    private Action OnBuildAreaHandler;
    private Action OnCancelActionHandler;

    public Button buildResidentialAreaBtn;
    public Button cancelActionBtn;
    public GameObject cancelActionPanel;
    #endregion

    #region Unity Methods
    void Start()
    {
        cancelActionPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelActionCallback);
    }

    void Update()
    {
        
    }

    #endregion

    private void OnBuildAreaCallback()
	{
        cancelActionPanel.SetActive(true);
        OnBuildAreaHandler?.Invoke();
	}
    private void OnCancelActionCallback()
	{
        cancelActionPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
	}

    public void AddListenerOnBuildAreaEvent(Action listener)
	{
        OnBuildAreaHandler += listener;
	}

    public void RemoveListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler -= listener;
    }

    public void AddListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler += listener;
    }

    public void RemoveListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler -= listener;
    }
}
