using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainTester : MonoBehaviour
{
    public bool enemyExists = false;
    private Collider otherEnemy;
    public GameObject effectToSpawn;

    private string abilityType;
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 7)
        {
            enemyExists = true;
            otherEnemy = other;
            if (effectToSpawn != null)
            {
                GameObject newSpell = Instantiate(effectToSpawn, gameObject.transform.position,
                    Quaternion.LookRotation(other.gameObject.transform.position - gameObject.transform.position));
            }
        }
    }

    public bool FoundEnemy()
    {
        return enemyExists;
    }

    public Collider OtherEnemy()
    {
        return otherEnemy;
    }

    public void SetAbilityType(string _abilityType)
    {
        this.abilityType = _abilityType;
    }

}
