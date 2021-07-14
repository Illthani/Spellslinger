using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Debug.Log($"target: {target}");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            transform.position = raycastHit.point;  
        }
    }
}
