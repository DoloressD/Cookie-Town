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
    private Action OnDemolishActionHandler;

    public Button buildResidentialAreaBtn;

    [Header("Cancel Menu")]
    public GameObject cancelActionPanel;
    public Button cancelActionBtn;


    [Header("Building Mode Menu")]
    public GameObject buildingMenuPanel;
    public Button openBuildMenuBtn;
    public Button demolishBtn;
    #endregion

    #region Unity Methods
    void Start()
    {
        cancelActionPanel.SetActive(false);
        buildingMenuPanel.SetActive(false);

        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelActionCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        demolishBtn.onClick.AddListener(OnDemolishActionCallback);
    }


	#endregion

	private void OnBuildAreaCallback()
	{
        cancelActionPanel.SetActive(true);
        buildingMenuPanel.SetActive(false);
        OnBuildAreaHandler?.Invoke();
	}
    private void OnCancelActionCallback()
	{
        cancelActionPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
	}

    private void OnOpenBuildMenu()
    {
        buildingMenuPanel.SetActive(true);
        cancelActionPanel.SetActive(false);
    }

    private void OnDemolishActionCallback()
    {
        cancelActionPanel.SetActive(true);
        buildingMenuPanel.SetActive(false);
        OnDemolishActionHandler?.Invoke();
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

    public void AddListenerOnDemolishlActionEvent(Action listener)
    {
        OnDemolishActionHandler += listener;
    }

    public void RemoveListenerOnDemolishActionEvent(Action listener)
    {
        OnDemolishActionHandler -= listener;
    }
}
