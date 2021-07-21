using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conduits : MonoBehaviour
{
    public GameObject ConduitVfx;

    [SerializeField] private List<GameObject> ConduitsList = new List<GameObject>(); 
    void Start()
    {
        Destroy(gameObject, 10f);
        for (int i = 0; i < 5; i++)
        {
            ConduitsList.Add(Instantiate(ConduitVfx, gameObject.transform.position, Quaternion.AngleAxis(72 * i, Vector3.up)));

        }
        for(int i = 0; i < 4; i++)
        {
            ConduitsList[i].GetComponent<SingleConduit>().nextConduit = ConduitsList[i+1];
        }

        ConduitsList[4].GetComponent<SingleConduit>().nextConduit = ConduitsList[0];
    }
}
