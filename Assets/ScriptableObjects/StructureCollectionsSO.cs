/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collection", menuName = "CityBuilder/CollectionData")]

public class StructureCollectionsSO : ScriptableObject
{
    public RoadStructureSO roadStructure;
    public List<SingleStructureBaseSO> singleStructureList;
    public List<ZoneStructureSO> zoneList;
}
