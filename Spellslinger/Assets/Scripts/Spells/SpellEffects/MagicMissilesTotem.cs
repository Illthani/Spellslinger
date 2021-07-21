using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissilesTotem : MonoBehaviour
{
    public GameObject MagicMissile;

    void Start()
    {
        Destroy(gameObject, 5f);    
        SpawnMagicMissile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMagicMissile()
    {
        Invoke("SpawnMagicMissile", 0.3f);
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up);
        Instantiate(MagicMissile, gameObject.transform.position, rotation);

    }
}
