using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{

    void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.forward * Time.deltaTime;
        Destroy(gameObject, 7.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<EnemyAttacking>().IDied();
            Destroy(gameObject);
        }

    }
}
