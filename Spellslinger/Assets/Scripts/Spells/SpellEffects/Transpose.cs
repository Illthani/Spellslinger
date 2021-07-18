using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transpose : MonoBehaviour
{
    public GameObject Transpose2Vfx;
    void Start()
    {
        Instantiate(Transpose2Vfx, gameObject.GetComponent<VariationCheck>().PlayerGO.transform.position,
            Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
