using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ChainLightningScript : MonoBehaviour
{
    private string variations;
    private int bounceCount;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bounceCount = 5;
        if (gameObject.GetComponent<VariationCheck>().Variation)
        {
            variations = GetComponent<VariationCheck>().VariationName;
        }
    }   

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            BounceAway(other);

        }
        else if (other.gameObject.layer == 7)
        {
            BounceAway(other);
//            Destroy(other.gameObject);
        }
    }

    void BounceAway(Collision other)
    {
        bounceCount--;
        Vector3 wallNormal = other.contacts[0].normal;
        Vector3 dir = Vector3.Reflect(rb.velocity, wallNormal);
        rb.velocity = dir * gameObject.GetComponent<MoveProjectile>().speed;
        Debug.Log("I exist");
//        if (bounceCount == 0)
//        {
//            Destroy(gameObject, 1f);
//        }
    }


}
