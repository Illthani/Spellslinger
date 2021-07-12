using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLength;

    private Quaternion targetRotation;
    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    void Start()
    {
        
    }


    void Update()
    {
        DoThis();

//        if (cam != null)
//        {
//            RaycastHit hit;
//            var mousePos = Input.mousePosition;
//            rayMouse = cam.ScreenPointToRay(mousePos);
//            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLength)
//            {
//                RotateToMouseDirection(gameObject, hit.point);
//            }
//        }
    }

    private void DoThis()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0f;
        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            targetRotation = Quaternion.LookRotation(targetPoint - transform.position); 

            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.fixedDeltaTime);
        }
    }
    void RotateToMouseDirection(GameObject obj, Vector3 destination)

    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
