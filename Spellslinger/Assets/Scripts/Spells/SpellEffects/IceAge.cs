using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAge : MonoBehaviour
{
    private bool increaseSize = false;
    private bool testThing = false;
    private float step = 0.0005f;
    private float radiusSize = 5f;
    void Start()
    {
        Invoke("ActivateCollider", 0.5f);
        switch (gameObject.GetComponent<VariationCheck>().VariationName)
        {
            case "":
            {
                break;
            }

            case "Size":
            {
                gameObject.transform.localScale *= 2;
                break;
            }
        }
    }

    void FixedUpdate()
    {
        if (increaseSize && gameObject.GetComponent<SphereCollider>().radius <= radiusSize)
        {
            IncreaseSize();
        }
    }

    private void ActivateCollider()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
        increaseSize = true;
    }
        
    private void IncreaseSize()
    {
        gameObject.GetComponent<SphereCollider>().radius += Mathf.Lerp(2f, radiusSize, step) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject, 0.5f);
        }
    }


}
