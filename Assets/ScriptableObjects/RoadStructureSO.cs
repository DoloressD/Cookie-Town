/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;


[CreateAssetMenu(fileName = "New Road Structure", menuName = "CityBuilder/StructureData/RoadStructure")]
public class RoadStructureSO : StructureBaseSO
{
    [Tooltip("Road Facing Up and Right")]
    public GameObject cornerPrefab;
    [Tooltip("Road Facing Up and Down")]
    public GameObject threeWayPrefab;
    public GameObject fourWayPrefab;
}
