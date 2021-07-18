using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
