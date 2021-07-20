using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirlingNova : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 10f);
        if (GetComponent<VariationCheck>().VariationName != "")
        {
            AdditiveEffects.NovaEffect(gameObject, 8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12 || other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }
}
