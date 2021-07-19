using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public float fireRate;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No speed");
        }

    }


}
