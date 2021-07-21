using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemyProjectile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 15f);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 11)
        {
            PlayerHit(other);
        }
    }

    void PlayerHit(Collider other)
    {
        GameObject PlayerGO = GameObject.Find("Player");
        PlayerGO.GetComponent<CharacterStatus>().DeathScreen();

//        other.gameObject.GetComponent<CharacterStatus>().DeathScreen();
    }
}
