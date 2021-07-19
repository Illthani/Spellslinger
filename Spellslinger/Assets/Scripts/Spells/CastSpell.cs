using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CastSpell : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject PlayerGO;
    private Vector3 spawnPosAdjustment = Vector3.up * 0.5f;


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
                Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
                GameObject vfx = Instantiate(spellVfx, firePoint.transform.position + spawnPosAdjustment, Quaternion.LookRotation(direction));
                vfx.GetComponent<VariationCheck>().VariationName = additiveName;
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
                GameObject vfx = Instantiate(spellVfx, PlayerGO.transform.position + spawnPosAdjustment, PlayerGO.transform.rotation);
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
            Vector3 spawnVector = UtilityScripts.GetMouseWorldPosition();
            spawnVector.y += 0.1f;
            GameObject vfx = Instantiate(spellVfx, UtilityScripts.GetMouseWorldPosition() + spawnPosAdjustment, PlayerGO.transform.rotation);
        }
        else
        {
            Debug.Log("Object is null at MouseButtonPosSpell()");
        }
    }

    public void RaycastSpell(GameObject spellVfx, string additiveName)
    {
        RaycastHit hit;
        Physics.Raycast(PlayerGO.transform.position, (UtilityScripts.GetMouseWorldPosition() - PlayerGO.transform.position) + spawnPosAdjustment, out hit, 20f, 11);
        if (hit.collider.gameObject.layer == 7)
        {
            GameObject spell = Instantiate(spellVfx, hit.collider.gameObject.transform.position, Quaternion.identity);
            spell.GetComponent<VariationCheck>().VariationName = additiveName;
            spell.GetComponent<VariationCheck>().PlayerGO = PlayerGO;
            spell.GetComponent<VariationCheck>().targetGO = hit.collider.gameObject;
        }

    }



    public void MouseButtonSpellCone(GameObject GO, int count, float step = 0.1f)
    {
        if (firePoint != null)
        {
            Vector3 direction = firePoint.transform.position - PlayerGO.transform.position;
            for (int i = -count; i <= count; i++)
            {
                Vector3 spawnPos = new Vector3(firePoint.transform.position.x, 0.2f, firePoint.transform.position.z);
                
                GameObject newSpell = Instantiate(GO, spawnPos, Quaternion.LookRotation(new Vector3(direction.x + i * step, 0f, direction.z + i * step)));

                
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
//            int additiveID = Random.Range(0, spellVariationList.Count);
            newSpell.GetComponent<VariationCheck>().VariationName = "";
        }
    }

}
