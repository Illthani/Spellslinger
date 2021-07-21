using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleConduitLightning : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 0.3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<EnemyAttacking>().IDied();
        }
    }
}
