using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlacialCascade : MonoBehaviour
{
    private string variation;

    void Start()
    {
        Destroy(gameObject, 4.5f);
        Invoke("EnableCollider", 2f);
        variation = gameObject.GetComponent<VariationCheck>().VariationName;
        Invoke("EnableCollider", 0.25f);
//        variation = "Size";
        switch (variation)
        {
            case "Cone":
            {
                AdditiveEffects.ConeEffect(gameObject, 1, 0.5f);
                break;
            }
            case "Size":
            {
                Vector3 scale = new Vector3(1f, 0.5f, 1f);
                
                Vector3 collScale = new Vector3(0.8f, 0.5f, 0.5f);
                gameObject.transform.localScale = 2 * scale;
                
                foreach (BoxCollider collider in gameObject.GetComponents<BoxCollider>())
                {
                    Vector3 boxScale = new Vector3(collider.size.x * 0.8f, collider.size.y, collider.size.y);
                    collider.size = boxScale;
                }
                break;
            }
            case "Volley":
            {
                AdditiveEffects.VolleyEffect(gameObject, 0.25f, 2);
                break;
            }
            case "Nova":
            {
                AdditiveEffects.NovaEffect(gameObject, 8);
                break;
            }
            default:
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableCollider()
    {
        foreach (BoxCollider collider in gameObject.GetComponents<BoxCollider>())
        {
            collider.enabled = !collider.enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<EnemyAttacking>().IDied();
        }

    }


}
