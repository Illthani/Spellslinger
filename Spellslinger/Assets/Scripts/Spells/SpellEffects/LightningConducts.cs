using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightningConducts : MonoBehaviour
{
    public GameObject electricityConduit;
    private Vector3 mousePos;
    private int maxConduits = 4;
    private int currentConduits = 1;

    private List<GameObject> electricityConduits = new List<GameObject>();

    void Start()
    {
            electricityConduits.Add(Instantiate(electricityConduit, gameObject.transform.position, Quaternion.identity, gameObject.transform));
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentConduits < maxConduits)
        {
            mousePos = UtilityScripts.GetMouseWorldPosition();
            electricityConduits.Add(Instantiate(electricityConduit, mousePos, Quaternion.identity, gameObject.transform));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyAttacking>().IDied();
    }
}