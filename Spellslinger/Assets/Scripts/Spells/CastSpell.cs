using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public List<GameObject> vfxList = new List<GameObject>();
    public GameObject firePoint;
    public GameObject PlayerGO;

    private GameObject effectToSpawn;
    private Quaternion targetRotation;


    void Start()
    {
        effectToSpawn = vfxList[0];
        targetRotation = PlayerGO.GetComponent<PlayerController>().targetRotation;
    }


    private void DoThis()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonSpell();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            QKeySpell();
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceSpell();
        }
    }

    public void MouseButtonSpell()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.LookRotation(direction)); 
            //vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.LookRotation() )
        }
        
    }
    

    public void QKeySpell()
    {

    }

    public void SpaceSpell()
    {

    }

}
