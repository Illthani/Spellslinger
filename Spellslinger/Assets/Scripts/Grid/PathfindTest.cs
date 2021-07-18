using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindTest : MonoBehaviour
{
    private Pathfinding pathfinding;
    public GameObject test;
    private void Start()
    {
        pathfinding = new Pathfinding(56, 64);
        for (int i = 0; i < pathfinding.GetGrid().GetWidth(); i++)
        {
            for (int j = 0; j < pathfinding.GetGrid().GetHeight(); j++)
            {
                Vector3 testVec = new Vector3(pathfinding.GetGrid().GetGridObject(i, j).x * pathfinding.GetGrid().GetCellSize() + pathfinding.GetGrid().GetCellSize() /2, 3f, pathfinding.GetGrid().GetGridObject(i, j).z * pathfinding.GetGrid().GetCellSize() + pathfinding.GetGrid().GetCellSize() / 2);
            }
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilityScripts.GetMouseWorldPosition();
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
            Vector3 mouseWPos = UtilityScripts.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXZ(mouseWPos, out int x1, out int z1);
            pathfinding.GetGrid().GetGridObject(x1, z1).isWalkable = !pathfinding.GetGrid().GetGridObject(x1, z1).isWalkable;
        }
    }
}
