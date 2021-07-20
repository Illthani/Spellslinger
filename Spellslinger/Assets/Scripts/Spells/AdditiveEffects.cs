using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class AdditiveEffects : MonoBehaviour
{

    public AdditiveEffects()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NestEffect(GameObject gameObjectOG, GameObject collTestPrefab, float collTestRadius = 10f)
    {
        GameObject colliderTester = Instantiate(collTestPrefab, gameObjectOG.transform.position, Quaternion.identity);
        colliderTester.GetComponent<ChainTester>().effectToSpawn = gameObjectOG;
        gameObjectOG.GetComponent<VariationCheck>().VariationName = "";
    }

    public static void NovaEffect(GameObject GO, int count = 8)
    {
        GameObject spellQuery = GameObject.Find("SpellQuery");
        spellQuery.GetComponent<CastSpell>().NovaEffect(GO, count);
        Destroy(GO);
    }

    public static void ConeEffect(GameObject GO, int count, float step = 0.1f)
    {
        GameObject spellQuery = GameObject.Find("SpellQuery");
        spellQuery.GetComponent<CastSpell>().MouseButtonSpellCone(GO, count, step);
        GameObject PlayerGO = GameObject.Find("Player");
        GameObject FirePoint = GameObject.Find("FirePoint");
        //spellQuery.GetComponent<CastSpell>().MouseButtonSpellCone(GO);
    }

    public static void BarrageEffect(GameObject GO, int count = 2, float step = 2f)
    {
        for (int i = -count; i <= count; i++)
        {

            Vector3 stepAdjustment = new Vector3(step, 0f, 0f);
            GameObject barrageSpell1 = Instantiate(GO, GO.transform.position, GO.transform.rotation, GO.transform);
            barrageSpell1.GetComponent<VariationCheck>().VariationName = "";
            barrageSpell1.transform.position = stepAdjustment * i;
            barrageSpell1.transform.parent = null;


        }
        Destroy(GO);
    }

    public static void Kill(GameObject GO, float timeDelay = 0f)
    {
        Destroy(GO, timeDelay);
    }

    public static void VolleyEffect(GameObject GO, float timerStep, int count = 5)
    {
       
    }

    public static void PlayerSpeed(GameObject PlayerGO, float speedChange)
    {
//        GetComponent<PlayerController>
    }





}
