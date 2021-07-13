using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private GridBase grid;
    private int x;
    private int z;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;

    public PathNode(GridBase _grid, int _x, int _z)
    {
        this.grid = _grid;
        this.x = _x;
        this.z = _z;
    }

    public override string ToString()
    {
        return $"x: {x} | z: {z}";
    }

}
