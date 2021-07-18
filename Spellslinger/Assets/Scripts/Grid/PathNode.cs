using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    private GridB<PathNode> grid;
    public int x;
    public int z;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;
    public PathNode cameFromNode;

    public GameObject testGO;
    public PathNode(GridB<PathNode> _grid, int _x, int _z, bool _isWalkable = true)
    {
        this.grid = _grid;
        this.x = _x;
        this.z = _z;
        isWalkable = _isWalkable;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return $"{x}|{z}";
    }

    public PathNode GetNode()
    {
        return this;
    }
}
