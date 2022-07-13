/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;

public class GridStructure 
{
    #region Variables
    private int cellSize = 3;
    #endregion
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);

        return new Vector3(x * cellSize, 0, z * cellSize);
    }
}
