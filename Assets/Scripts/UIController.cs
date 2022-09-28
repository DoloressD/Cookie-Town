/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Variables
    private Action<string> OnBuildAreaHandler;
    private Action<string> OnBuildSingleStructureHandler;
    private Action<string> OnBuildRoadHandler;
    private Action OnCancelActionHandler;
    private Action OnDemolishActionHandler;

    public StructureHolder structureCollection;

    public Button buildResidentialAreaBtn;

    [Header("Cancel Menu")]
    public GameObject cancelActionPanel;
    public Button cancelActionBtn;


    [Header("Building Mode Menu")]
    public GameObject buildingModePanel;
    public GameObject zonesPanel;
    public GameObject facilitiesPanel;
    public GameObject roadsPanel;
    public Button openBuildMenuBtn;
    public Button demolishBtn;
    public Button closeBuildMenuBtn;
    public GameObject buildButtonPrefab;
    #endregion

    #region Unity Methods
    void Start()
    {
        cancelActionPanel.SetActive(false);
        buildingModePanel.SetActive(false);

        //buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelActionCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        demolishBtn.onClick.AddListener(OnDemolishActionCallback);
        closeBuildMenuBtn.onClick.AddListener(OnCloseBuildMenuHandler);
    }

	#endregion

	private void OnBuildAreaCallback(string structureName)
	{
		BuildUISetup();
		OnBuildAreaHandler?.Invoke(structureName);
	}

    private void OnBuildSingleStructureCallback(string structureName)
    {
        BuildUISetup();
        OnBuildSingleStructureHandler?.Invoke(structureName);
    }

    private void OnBuildRoadCallback(string structureName)
    {
        BuildUISetup();
        OnBuildRoadHandler?.Invoke(structureName);
    }

    private void BuildUISetup()
	{
		cancelActionPanel.SetActive(true);
		OnCloseBuildMenuHandler();
	}

	private void OnCancelActionCallback()
	{
        cancelActionPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
	}

    private void OnOpenBuildMenu()
    {
        buildingModePanel.SetActive(true);
        cancelActionPanel.SetActive(false);
        SetupBuildMenu();
    }

    private void SetupBuildMenu()
	{
        CreateButtonsInPanel(zonesPanel.transform, structureCollection.GetZoneNames(), OnBuildAreaCallback);
        CreateButtonsInPanel(facilitiesPanel.transform, structureCollection.GetSingleStructureNames(), OnBuildSingleStructureCallback) ;
        CreateButtonsInPanel(roadsPanel.transform, new List<string>() { structureCollection.GetRoadStructureName() }, OnBuildRoadCallback);
    }

	private void CreateButtonsInPanel(Transform panelTransform, List<string> data, Action<string> callBack)
	{
        if(data.Count > panelTransform.childCount)
		{
            int quantityDiff = data.Count - panelTransform.childCount;
			for (int i = 0; i < quantityDiff; i++)
			{
                Instantiate(buildButtonPrefab, panelTransform);
			}
		}
		for (int i = 0; i < panelTransform.childCount; i++)
		{
            var button = panelTransform.GetChild(i).GetComponent<Button>();
            if (button != null)
            {
                button.onClick.RemoveAllListeners();
                button.GetComponentInChildren<TextMeshProUGUI>().text = data[i];
                button.onClick.AddListener(() => callBack(button.GetComponentInChildren<TextMeshProUGUI>().text));
            }
        }
	}

	private void OnDemolishActionCallback()
    {
        cancelActionPanel.SetActive(true);
        OnCloseBuildMenuHandler();
        OnDemolishActionHandler?.Invoke();
    }

    private void OnCloseBuildMenuHandler()
    {
        buildingModePanel.SetActive(false);
    }


    public void AddListenerOnBuildAreaEvent(Action<string> listener)
	{
        OnBuildAreaHandler += listener;
	}

    public void RemoveListenerOnBuildAreaEvent(Action<string> listener)
    {
        OnBuildAreaHandler -= listener;
    }


    public void AddListenerOnBuildSingleStructureEvent(Action<string> listener)
    {
        OnBuildSingleStructureHandler += listener;
    }

    public void RemoveListenerOnBuildSingleStructureEvent(Action<string> listener)
    {
        OnBuildSingleStructureHandler -= listener;
    }

    public void AddListenerOnBuildRoadEvent(Action<string> listener)
    {
        OnBuildRoadHandler += listener;
    }

    public void RemoveListenerOnBuildRoadEvent(Action<string> listener)
    {
        OnBuildRoadHandler -= listener;
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
