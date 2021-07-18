using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minSpawnCooldown;
    public float maxSpawnCooldown;
    private float spawnEnemyCooldown;
    public GameObject spawnVfx;
    public List<GameObject> EnemyGOList;
    public GameObject PlayerGO;
    public GameObject firePoint;
    void Start()
    {
        SpawnTimeRandomizer();
    }


    void SpawnTimeRandomizer()
    {
        spawnEnemyCooldown = Random.Range(minSpawnCooldown, maxSpawnCooldown);
        Invoke("SpawnEnemy", spawnEnemyCooldown);
    }

    void SpawnEnemy()
    {
        int randEnemySelection = Random.Range(0, EnemyGOList.Count);

        GameObject enemyGO = Instantiate(EnemyGOList[randEnemySelection], gameObject.transform.position, Quaternion.identity);
        enemyGO.GetComponent<EnemyAttacking>().PlayerGO = PlayerGO;
//        GameObject fp = enemyGO.transform.Find("FirePoint").gameObject;
//        enemyGO.GetComponent<EnemyAttacking>().firePoint = fp;

        GameObject spawnVfxGO = Instantiate(spawnVfx, gameObject.transform.position, Quaternion.identity);
        Destroy(spawnVfxGO, 2f);
        SpawnTimeRandomizer();
    }
}
