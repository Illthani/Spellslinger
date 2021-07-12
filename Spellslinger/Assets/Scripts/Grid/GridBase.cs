using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase
{
    private int width;
    private int height;
    private int[,] gridArray;

    public GridBase(int width, int height)
    {
        this.width = width;
        this.height = height;
        gridArray = new int[width, height];

        Debug.Log($"{this.width} + {this.height}");
    }
}
