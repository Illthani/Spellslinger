using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIceVolleyColl : MonoBehaviour
{

    [SerializeField] private bool startMoving = false;
    [SerializeField] private float distanceTotalTime = 1f;
    [SerializeField] private float delayTotalTime = 1f;
    [SerializeField] private Vector3 direction = Vector3.zero;
    [SerializeField] private float forwardModifier = 0.627f;
    private Vector3 aimDirection = Vector3.zero;
    void FixedUpdate()
    {
        if (delayTotalTime > 0)
        {
            delayTotalTime -= Time.deltaTime;

        }
        else
        {
            startMoving = true;
        }


        if (startMoving && distanceTotalTime > 0)
        {
            this.gameObject.transform.Translate(Vector3.forward * forwardModifier);
            
            distanceTotalTime -= 0.02f;
        }
    }

    public void SetDelay(float delayTime)
    {
        delayTotalTime = delayTime;

    }

    public void SetDistanceTime(float distanceTime)
    {
        distanceTotalTime = distanceTime;
    }

    public void SetDirection(Vector3 dir)
    {
        aimDirection = dir;
    }

    public void SetModifier(float mod)
    {
        forwardModifier = mod;
    }
}
