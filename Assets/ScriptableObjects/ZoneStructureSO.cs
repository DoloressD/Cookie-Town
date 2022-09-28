/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

[CreateAssetMenu(fileName = "New Zone Structure", menuName = "CityBuilder/StructureData/ZoneStructure")]
public class ZoneStructureSO : StructureBaseSO
{
	public bool upgradable;
	public GameObject[] prefabVariants;
	public UpgradeType[] availableUpgrades;
	public ZoneType zoneType;
}

[System.Serializable]
public struct UpgradeType
{
	public GameObject[] prefabVariants;
	public int maxHappiness;
	public int newIncome;
	public int newUpkeep;
}

public enum ZoneType
{
	Residential,
	Commercial,
	Agricultural
}
