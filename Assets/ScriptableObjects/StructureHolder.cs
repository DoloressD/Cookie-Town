/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StructureHolder : MonoBehaviour
{
    public StructureCollectionsSO structureCollection;

    #region Variables
    #endregion

    #region Unity Methods
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    public List<string> GetZoneNames()
	{
        return structureCollection.zoneList.Select(zone => zone.buildingName).ToList();
	}

    public List<string> GetSingleStructureNames()
	{
        return structureCollection.singleStructureList.Select(facility => facility.buildingName).ToList();
    }

    public string GetRoadStructureName()
	{
        return structureCollection.roadStructure.buildingName;
	}
}
