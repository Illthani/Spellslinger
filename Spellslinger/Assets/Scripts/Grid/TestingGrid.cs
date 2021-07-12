using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    private GridBase grid;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridBase(20, 10, 10f, new Vector3(5, 0, 5));



    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            grid.GetValue(GetMouseWorldPosition());
        }
    }


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
}
