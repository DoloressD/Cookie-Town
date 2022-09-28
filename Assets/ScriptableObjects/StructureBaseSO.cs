/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public abstract class StructureBaseSO : ScriptableObject
{
    public string buildingName;
    public GameObject prefab;
    public int buildingCost;
    public int upkeepCost;
    public int income;
    public bool needRoadAccess;
    public bool needWater;
    public bool needPower;
}
