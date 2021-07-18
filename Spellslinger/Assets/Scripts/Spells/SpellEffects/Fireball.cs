using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private GameObject collTestPrefab;
    private LayerMask enemyLayer;
    private bool variate = true;
    private string variations;
    [SerializeField] private ParticleSystem ps;


    void Start()
    {
        Destroy(gameObject, 10f);
        if (gameObject.GetComponent<VariationCheck>().Variation)
        {
            variations = GetComponent<VariationCheck>().VariationName;
            //variations = "Cone";
            switch(variations)
            {
                case "Ghost":
                {
                    gameObject.transform.localScale *= 3;
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        gameObject.transform.GetChild(i).localScale *= 3;
                    }
                    break;
                }
                case "Cone":
                {
                    AdditiveEffects.ConeEffect(gameObject, 2);
                    break;
                }
                case "Nova":
                {
                    AdditiveEffects.NovaEffect(gameObject, 8);
                    break;
                }
                case "Barrage":
                {
                    AdditiveEffects.BarrageEffect(gameObject);
                    break;
                }
                default:
                {
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
   
        switch (other.gameObject.layer)
        {
            case 6:
            {
                if(variations != "Ghost")
                Destroy(gameObject, 0.05f);
                break;
            }
            case 7:
            {
                if (variations != "Ghost")
                {
                    Destroy(gameObject, 0.05f);
                }
                Destroy(other.gameObject);
                if (variations == "Nest")
                {
                    AdditiveEffects.NestEffect(gameObject, collTestPrefab, 10f);
                }
                
                
                break;
            }
            default:
            {
                break;
            }
            
        }


    }
}
