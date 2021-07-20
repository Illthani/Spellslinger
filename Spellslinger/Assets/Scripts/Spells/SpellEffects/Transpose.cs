using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transpose : MonoBehaviour
{
    public GameObject Transpose2Vfx;
    public GameObject PlayerGO;
    public GameObject EnemyGO;

    void Start()
    {
        switch (GetComponent<VariationCheck>().VariationName)
        {
            case "Kill":
            {
                AdditiveEffects.Kill(EnemyGO);
                break;
            }

            case "PSpeed":
            {
                AdditiveEffects.PlayerSpeed(PlayerGO, 5f);
                ReturnSpeed();
                break;
            }
            default:
            {
                break;
            }
        }
        Destroy(gameObject, 1f);
        Instantiate(Transpose2Vfx, PlayerGO.transform.position, Quaternion.identity);
        Instantiate(Transpose2Vfx, PlayerGO.transform.position, Quaternion.identity);
        SwapTwoObjectPlaces();
//        Instantiate(Transpose2Vfx, gameObject.GetComponent<VariationCheck>().PlayerGO.transform.position,
//            Quaternion.identity);
//        Instantiate(Transpose2Vfx, gameObject.GetComponent<VariationCheck>().EnemyGO.transform.position,
//            Quaternion.identity);
    }

    IEnumerator ReturnSpeed()
    {
        yield return new WaitForSeconds(0.5f);
        AdditiveEffects.PlayerSpeed(PlayerGO, -5f);

    }
    void SwapTwoObjectPlaces()
    {
        EnemyGO.SetActive(false);
        PlayerGO.transform.position = EnemyGO.transform.position;
        EnemyGO.transform.position = PlayerGO.transform.position;
        EnemyGO.SetActive(true);
    }

    void Update()
    {
        
    }

}
