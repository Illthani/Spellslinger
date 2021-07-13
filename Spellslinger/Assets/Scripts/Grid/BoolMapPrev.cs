using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolMapPrev : MonoBehaviour
{
    private GridB<bool> grid;
    private Mesh mesh;
    private bool updateMesh;


    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid(GridB<bool> _grid)
    {
        this.grid = _grid;
        UpdateBoolMapVisual();

        grid.OnGridObjectChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, GridB<bool>.OnGridObjectChangedEventArgs e)
    {
        updateMesh = true;
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateBoolMapVisual();
        }
    }

    private void UpdateBoolMapVisual()
    {
        //MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] Vertices, out Vector2[] uv, out int [] triangles)

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int z = 0; z < grid.GetHeight(); z++)
            {
                int index = x * grid.GetHeight() + z;

                Vector3 quadSize = new Vector3(1, 0, 1) * grid.GetCellSize();

                bool gridValue = grid.GetGridObject(x, z);
                float gridValueNormalized = gridValue ? 1f : 0f;

                Vector2 gridValueUV = new Vector2(gridValueNormalized, 0f);
                
            }

        }
       
    }
}
