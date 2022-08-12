/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    #region Variables
    public GameObject buildingPrefab;
    public Transform ground;
    #endregion

    #region Unity Methods
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    public void CreateBuilding(Vector3 gridPosition, GridStructure grid)
    {
        GameObject newStructure = Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
    }
}
