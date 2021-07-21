using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfiniteFireball : MonoBehaviour
{
    [SerializeField]
    private GameObject collTestPrefab;
    [SerializeField] private ParticleSystem ps;


    void Start()
    {
        Destroy(gameObject, 5f);
    }


    void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.layer)
        {
            case 6:
            {
                Destroy(gameObject, 0.05f);
                break;
            }
            case 7:
            {
                other.gameObject.GetComponent<EnemyAttacking>().IDied();
                AdditiveEffects.NestEffect(gameObject, collTestPrefab, 10f);

                break;
            }
            default:
            {
                break;
            }

        }


    }
}
