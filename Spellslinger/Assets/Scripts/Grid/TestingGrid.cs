using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    private GridB<HeatMapGridObject> grid;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private BoolMap boolMapVisual;


    // Start is called before the first frame update
    void Start()
    {
        grid = new GridB<HeatMapGridObject>(20, 10, 4f, Vector3.zero, (GridB<HeatMapGridObject> g, int x, int z) => new HeatMapGridObject(g, x, z));

//        boolMapVisual.SetGrid(grid);
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = GetMouseWorldPosition();
            Debug.Log("Now This");
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);
            if (heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            grid.GetGridObject(GetMouseWorldPosition());
        }   
    }



public class HeatMapGridObject
{
    private const int MIN = 0;
    private const int MAX = 100;

    private int x;
    private int z;
    private GridB<HeatMapGridObject> grid;
    public int value;

    public HeatMapGridObject(GridB<HeatMapGridObject> _grid, int _x, int _z)
    {
        this.grid = _grid;
        this.x = _x;
        this.z = _z;
    }


    
    public void AddValue(int addValue)
    {
        value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, z);
    }


    public float GetValueNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

// UTILS
// ---------------------------------------------------------
// UTILS

// Get Mouse Position in World with Z = 0f
public static Vector3 GetMouseWorldPosition()
{
    Vector3 vec = Vector3.zero;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
    {
        vec = new Vector3(raycastHit.point.x, 0f, raycastHit.point.z);
    }
    //Vector3 vec = GetMouseWorldPositionWithY(Input.mousePosition, Camera.main);
    Debug.Log($"{vec}");

    return vec;
}

public static Vector3 GetMouseWorldPositionWithY()
{
    return GetMouseWorldPositionWithY(Input.mousePosition, Camera.main);
}

public static Vector3 GetMouseWorldPositionWithY(Camera worldCamera)
{
    return GetMouseWorldPositionWithY(Input.mousePosition, worldCamera);
}

public static Vector3 GetMouseWorldPositionWithY(Vector3 screenPosition, Camera worldCamera)
{
    Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
    return worldPosition;
}

public static Vector3 GetDirToMouse(Vector3 fromPosition)
{
    Vector3 mouseWorldPosition = GetMouseWorldPosition();
    return (mouseWorldPosition - fromPosition).normalized;
}

// UTILS
// ---------------------------------------------------------
// UTILS
}