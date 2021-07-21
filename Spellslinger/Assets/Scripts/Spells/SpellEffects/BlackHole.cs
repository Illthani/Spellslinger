using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BlackHole : MonoBehaviour
{
    private List<Collider> allTrapped = new List<Collider>();
    private bool continueSucking = true;
    private float suckingForce;
    void Start()
    {
        //gameObject.GetComponent<SphereCollider>().radius *= 5;
        suckingForce = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (continueSucking)
        {
            suckingForce += 0.001f;
        }
        else
        {
            suckingForce = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            allTrapped.Add(other);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && suckingForce <= 1)
            
        {
            
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position,
                gameObject.transform.position, suckingForce);
        }

        else if(suckingForce >= 1)
        {
            if (other.gameObject.layer == 7)
            {
                Vector3 push = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));

                other.gameObject.GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);

                Invoke("Annihilate", 2.5f);
            }

        }

       
    }

    void Annihilate()
    {
        foreach (Collider col in allTrapped)
        {
            if (col != null)
            {
                col.gameObject.GetComponent<EnemyAttacking>().IDied();
            }
        }

        Destroy(gameObject);
    }
}
