using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class VariationCheck : MonoBehaviour
{
    public bool Variation = true;
    public int VariationID;
    public string SpellName;
    public string VariationName;
    public GameObject collTestPrefab;
    public GameObject PlayerGO;
    public GameObject targetGO;
    public int additionalVar;


//    public void VariationCheckVar(GameObject GO)
//    {
//        GameObject spellQuery = GameObject.Find("SpellQuery");
//        spellQuery.GetComponent<CastSpell>().MouseButtonSpellCone(GO);
//        GameObject PlayerGO = GameObject.Find("Player");
//        GameObject FirePoint = GameObject.Find("FirePoint");
//    }
}
