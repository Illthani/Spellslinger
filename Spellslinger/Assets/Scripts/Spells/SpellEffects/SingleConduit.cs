using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleConduit : MonoBehaviour
{
    public GameObject nextConduit;
    public GameObject conduitLightning;
    private bool expand = true;
    void Start()
    {
        Destroy(gameObject, 10f);
        Invoke("StopExpanding", 2.5f);
        ConduitLightning();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (expand)
        {
            gameObject.transform.position += transform.forward * 0.1f;
        }


    }

    private void ConduitLightning()
    {
        Instantiate(conduitLightning, gameObject.transform.position, Quaternion.LookRotation(nextConduit.transform.position - gameObject.transform.position));
        Invoke("ConduitLightning", 0.5f);
    }

    private void StopExpanding()
    {
        expand = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<EnemyAttacking>().IDied();
        }
    }
}
