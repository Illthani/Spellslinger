using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    private GridBase grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridBase(20, 10, 10f);
            
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(), 56);
            Debug.Log($"{GetMouseWorldPosition()}");
        }

        if (Input.GetMouseButtonDown(1))
        {
            grid.GetValue(GetMouseWorldPosition());
            Debug.Log($"{grid.GetValue(GetMouseWorldPosition())}");
        }
    }


    // Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithY(Input.mousePosition, Camera.main);
        vec.y = 0f;
//        Debug.Log($"{vec}");

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
}
