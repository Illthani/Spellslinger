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


    }


    private void SpellList()
    {

    }


    public void AttemptCast(GameObject spellVfx, string additiveName, string castType)
    {
        switch (castType)
        {
            case "FirePoint":
            {
                FirePointSpell(spellVfx, additiveName);
                break;
            }
            case "PlayerCentered":
            {
                PlayerCenteredSpell(spellVfx, additiveName);
                break;
            }
            case "MousePosition":
            {
                MouseButtonPosSpell(spellVfx, additiveName);
                break;
            }
            case "Raycast":
            {
                
                break;
            }
            default:
            {
                break;
            }
        }
    }
    void Update()
    {
    }

    public void FirePointSpell(GameObject spellVfx, string additiveName)
    {
        if (spellVfx != null)
        {
            if (firePoint != null)
            {
                Debug.Log("1");
                Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
                Debug.Log("2");

                GameObject vfx = Instantiate(spellVfx, firePoint.transform.position, Quaternion.LookRotation(direction));
                Debug.Log("3");

                vfx.GetComponent<VariationCheck>().VariationName = additiveName;
                Debug.Log("4");

            }
            else
            {
                Debug.Log("Object is null at FirePointSpell()");
            }
        }
    }

    public void PlayerCenteredSpell(GameObject spellVfx, string additiveName)
    {
        if (spellVfx != null)
        {
                Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
                GameObject vfx = Instantiate(spellVfx, PlayerGO.transform.position,PlayerGO.transform.rotation);
                vfx.GetComponent<VariationCheck>().VariationName = additiveName;
        }
        else
        {
            Debug.Log("Object is null at PlayerCenteredSpell()");
        }
    }





    public void MouseButtonPosSpell(GameObject spellVfx, string additiveName)
    {
        if (spellVfx != null)
        {
            GameObject vfx = Instantiate(spellVfx, UtilityScripts.GetMouseWorldPosition(), PlayerGO.transform.rotation);
        }
        else
        {
            Debug.Log("Object is null at MouseButtonPosSpell()");
        }
    }

    public void RaycastSpell()
    {

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

}
