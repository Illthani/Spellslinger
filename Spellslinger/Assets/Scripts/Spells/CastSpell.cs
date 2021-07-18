using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public List<GameObject> vfxList = new List<GameObject>();
    public GameObject firePoint;
    public GameObject PlayerGO;
    public Dictionary<string, List<string>> spellVariationList = new Dictionary<string, List<string>>();
    public bool canCast = true;

    private GameObject effectToSpawn;
    private Quaternion targetRotation;


    void Start()
    {
        int randomSpellID = Random.Range(0, vfxList.Count);
        string spellToSpawnName = vfxList[randomSpellID].name;

        effectToSpawn = vfxList[0];
        targetRotation = PlayerGO.GetComponent<PlayerController>().targetRotation;
        FillDictionary();
    }


    private void SpellList()
    {

    }

    void Update()
    {
        if (canCast)
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
    }

    public void MouseButtonSpell()
    {
        GameObject vfx;
        if (firePoint != null)
        {

            Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.LookRotation(direction));
            int spellVarID = Random.Range(0, spellVariationList["Fireball"].Count);
//            vfx.GetComponent<VariationCheck>().VariationName = "Barrage";

            vfx.GetComponent<VariationCheck>().VariationName = spellVariationList["Fireball"][spellVarID];
//            Debug.Log(vfx.GetComponent<VariationCheck>().VariationName);
        }
        
    }

    public void NovaEffect(GameObject GO, int count = 8)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newSpell = Instantiate(GO, GO.transform.position, Quaternion.AngleAxis(45f * i, Vector3.up));
                //Instantiate(GO, firePoint.transform.position,
                //Quaternion.AngleAxis(45f * i, Vector3.forward));
                int additiveID = Random.Range(0, spellVariationList.Count);
            newSpell.GetComponent<VariationCheck>().VariationName = "";
        }
    }

    public void MouseButtonPosSpell()
    {
        GameObject vfx;
        Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
        vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.LookRotation(direction));

    }

    public void MouseButtonSpellCone(GameObject GO, int count, float step = 0.1f)
    {
        if (firePoint != null)
        {
            Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
            for (int i = -count; i <= count; i++)
            {
                GameObject newSpell = Instantiate(effectToSpawn, firePoint.transform.position,
                    Quaternion.LookRotation(new Vector3(direction.x + i * 0.1f, 0f, direction.z + i * 0.1f)));
                
                newSpell.GetComponent<VariationCheck>().VariationName = "";
            }
        }

    }


    public void QKeySpell()
    {

    }

    public void SpaceSpell()
    {

    }



    private void FillDictionary()
    {
        List<string> FireballDict = new List<string>();
        FireballDict.Add("Ghost");
        FireballDict.Add("Cone");
        FireballDict.Add("Nest");
        FireballDict.Add("Chain");
        FireballDict.Add("Nova");
        FireballDict.Add("Volley");
        //FireballDict.Add("Barrage");
        
        // 1 - Ghost Fireball | 2 - Cone Fireball | 3 - Nest | 4 - Chain 


        spellVariationList.Add("Fireball", FireballDict);

        
    }
    

}
