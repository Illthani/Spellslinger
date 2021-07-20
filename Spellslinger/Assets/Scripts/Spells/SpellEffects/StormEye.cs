using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormEye : MonoBehaviour
{
    private SphereCollider collider;
    void Start()
    {
        collider = gameObject.GetComponent<SphereCollider>();
        Invoke("DisableCollider", 1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collider.radius += Time.deltaTime * 7f;
    }

    void DisableCollider()
    {
        Debug.Log(collider.radius);
        collider.enabled = false;
        Destroy(gameObject, 1f);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position,-gameObject.transform.position, 0.1f);
        }

        else if (other.gameObject.layer == 12)
        {
            Destroy(other.gameObject);
        }
    }
}
