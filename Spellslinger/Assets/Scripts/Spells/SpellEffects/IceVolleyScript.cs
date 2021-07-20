using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IceVolleyScript : MonoBehaviour
{
    private BoxCollider firstSpike;
    private GameObject firstSpikeGO;
    [SerializeField] private float firstSpikeSize = 2f;
    [SerializeField] private float distanceTotalTime;
    [SerializeField] private float delayTotalTime;
    [SerializeField] private GameObject PlayerGO;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private float sizeMod = 1f;
    
    private bool createdMoreBoxes = false;
    private Vector3 direction;

    void Start()
    {


        CreateMoreBoxes();
        firstSpikeGO = new GameObject("spikeCollider");
        firstSpikeGO.transform.rotation = Quaternion.LookRotation(direction);
        firstSpikeGO.transform.parent = this.gameObject.transform;
        firstSpikeGO.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + firstSpikeSize / 2, this.gameObject.transform.position.z);
        firstSpike = firstSpikeGO.AddComponent<BoxCollider>();
        firstSpike.isTrigger = true;
        firstSpike.size = new Vector3(firstSpikeSize * sizeMod, firstSpikeSize * sizeMod, firstSpikeSize * sizeMod);
        firstSpike.gameObject.AddComponent<MoveIceVolleyColl>();
        firstSpike.GetComponent<MoveIceVolleyColl>().SetDelay(delayTotalTime);
        firstSpike.GetComponent<MoveIceVolleyColl>().SetDelay(distanceTotalTime);
        if(sizeMod == 2)
            firstSpike.GetComponent<MoveIceVolleyColl>().SetModifier(1.254f);
    }

    private void CreateMoreBoxes()
    {
        if (!createdMoreBoxes)
        {
            if (gameObject.GetComponent<VariationCheck>().SpellName == "Size")
            { SizeVariation(); }
            createdMoreBoxes = true;
            firePoint = GameObject.Find("FirePoint");
            PlayerGO = GameObject.Find("Player");
            Invoke("Start", 1f);
            Invoke("Start", 1.4f);
            Invoke("Start", 1.5f);
            Invoke("IceCube", 3.2f);
            direction = firePoint.transform.position - PlayerGO.transform.position;

        }
    }

    private void IceCube()
    {
        GameObject BigIce = new GameObject("big ice");
        //Quaternion lookRot = Quaternion.LookRotation(direction);
        BigIce.transform.rotation = Quaternion.LookRotation(direction);

        //GameObject BigIce = new GameObject("bigIce");
        BigIce.transform.parent = this.gameObject.transform;
        BigIce.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z);

        BoxCollider BigIceBox = BigIce.AddComponent<BoxCollider>();
        BigIceBox.isTrigger = true;
        BigIceBox.size = new Vector3(7.5f * sizeMod, 4f * sizeMod, 7.5f * sizeMod);
        BigIce.AddComponent<MoveIceVolleyColl>();
        BigIce.GetComponent<MoveIceVolleyColl>().SetDelay(0.55f);
        BigIce.GetComponent<MoveIceVolleyColl>().SetDistanceTime(0.9f);
        BigIce.GetComponent<MoveIceVolleyColl>().SetModifier(0.7f); // 0.7 original
        if (sizeMod == 2)
        {
            BigIce.GetComponent<MoveIceVolleyColl>().SetModifier(1.4f);
        }

    }

    private void SizeVariation()
    {
        sizeMod = 2f;
        gameObject.transform.localScale *= 2;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) 
        {
            other.gameObject.GetComponent<EnemyAttacking>().IDied();
        }
    }

}
