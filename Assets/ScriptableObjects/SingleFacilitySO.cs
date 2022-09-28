/*
* Copyright (c) LaCookieFreak
* http://lacookiefreak.com
*/

using UnityEngine;


[CreateAssetMenu(fileName = "New Facility", menuName = "CityBuilder/StructureData/Facility")]
public class SingleFacilitySO : SingleStructureBaseSO
{
    public int maxCustomers;
    public int upKeepPerCustomer;
}
