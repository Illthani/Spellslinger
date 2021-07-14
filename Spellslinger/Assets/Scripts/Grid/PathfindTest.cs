using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindTest : MonoBehaviour
{
    private Pathfinding pathfinding;
    public GameObject test;
    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
        for (int i = 0; i < pathfinding.GetGrid().GetWidth(); i++)
        {
            for (int j = 0; j < pathfinding.GetGrid().GetHeight(); j++)
            {
                Debug.Log(pathfinding.GetGrid().GetGridObject(i, j));
                Vector3 testVec = new Vector3(pathfinding.GetGrid().GetGridObject(i, j).x * pathfinding.GetGrid().GetCellSize() + pathfinding.GetGrid().GetCellSize() /2, 3f, pathfinding.GetGrid().GetGridObject(i, j).z * pathfinding.GetGrid().GetCellSize() + pathfinding.GetGrid().GetCellSize() / 2);

                //GameObject testyBoi = Instantiate(test, testVec, Quaternion.identity);
            }
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXZ(mouseWorldPosition, out int x, out int z);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, z);

            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, 0f, path[i].z) * 10f + Vector3.one * 5f,
                    new Vector3(path[i].x, 3f, path[i].z));
                    
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWPos = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXZ(mouseWPos, out int x1, out int z1);
            pathfinding.GetGrid().GetGridObject(x1, z1).isWalkable = !pathfinding.GetGrid().GetGridObject(x1, z1).isWalkable;
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
        {
            vec = new Vector3(raycastHit.point.x, 0f, raycastHit.point.z);
        }
        //Vector3 vec = GetMouseWorldPositionWithY(Input.mousePosition, Camera.main);

        return vec;
    }

}
