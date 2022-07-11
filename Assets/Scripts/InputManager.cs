using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask;
    public GameObject buildingPrefab;
    public int cellsize = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray.origin,ray.direction, out hit, Mathf.Infinity, mouseInputMask))
            {
                Vector3 position = hit.point - transform.position;
                Debug.Log(CalculateGridPosition(position));
                CreateBuilding(CalculateGridPosition(position));
            }
        }
    }

    public Vector3 CalculateGridPosition (Vector3 inputPosition)
	{
        int x = Mathf.FloorToInt((float)inputPosition.x / cellsize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellsize);

        return new Vector3(x * cellsize, 0, z * cellsize);
    }

    private void CreateBuilding(Vector3 gridPosition)
	{
        Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
	}
}
