using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpellRotation : MonoBehaviour
{
    private Dictionary<string, List<string>> spellVariationList;

    public Dictionary<string, SpellEffect> BasicSpells;
    public Dictionary<string, SpellEffect> UltimateSpells;
    public Dictionary<string, SpellEffect> UtilitySpells;
    private List<string> BasicSpellNames;
    private List<string> UltimateSpellNames;
    private List<string> UtilitySpellNames;

    private SpellEffect basicSpellEffect;
    private SpellEffect utilitySpellEffect;
    private SpellEffect ultimateSpellEffect;
    private int BasicAdditiveEffectID;
    private int UtilityAdditiveEffectID;
    private int UltimateAdditiveEffectID;
    private string basicPreviousSpell;
    private string utilityPreviousSpell;
    private string ultimatePreviousSpell;

    [Header("Textures")]
    public Texture fireballTexture;
    public Texture iceVolleyTexture;
    public Texture blackholeTexture;
    public Texture chainLightningTexture;
    public Texture iceCageTexture;
    public Texture iceAgeTexture;
    public Texture windTunnelTexture;
    public Texture hurricaneTexture;
    public Texture swirlingNovaTexture;
    public Texture stormEyeTexture;
    public Texture glacialCascadeTexture;
    public Texture flameDashTexture;
    public Texture transposeTexture;
    public Texture magicMissilesTexture;
    public Texture infiniteFireballTexture;
    public Texture conduitsTexture;

    [Header("Vfx")]
    public GameObject fireballVfx; 
    public GameObject iceVolleyVfx;
    public GameObject blackholeVfx;
    public GameObject chainLightningVfx;
    public GameObject iceCageVfx;
    public GameObject iceAgeVfx;
    public GameObject windTunnelVfx;
    public GameObject hurricaneVfx;
    public GameObject swirlingNovaVfx;
    public GameObject stormEyeVfx;
    public GameObject glacialCascadeVfx;
    public GameObject flameDashVfx;
    public GameObject transposeVfx;
    public GameObject magicMissilesVfx;
    public GameObject infiniteFireballVfx;
    public GameObject conduitsVfx;

    private float spellTimer;
    private float spellTimerMax = 1f;

    private string currentBasicSpell;
    private string currentUtilitySpell;
    private string currentUltimateSpell;

    void Start()
    {
        spellTimer = spellTimerMax;
        AllSpellList();
    }

    private void AllSpellList()
    {
        BasicSpells = BasicSpellList();
        UltimateSpells = UltimateSpellList();
        UtilitySpells = UtilitySpellList();

        BasicSpellNames = BasicSpellNameList();
        UtilitySpellNames = UtilitySpellNameList();
        UltimateSpellNames = UltimateSpellNameList();

        RotateAllSpells();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (spellTimer <= 0f)
            {

                RotateAllSpells();

                CastSpell(BasicSpells[currentBasicSpell], currentBasicSpell, BasicAdditiveEffectID);
                CastSpell(UtilitySpells[currentUtilitySpell], currentUtilitySpell, UtilityAdditiveEffectID);
                CastSpell(UltimateSpells[currentUltimateSpell], currentUltimateSpell, UltimateAdditiveEffectID);
            }
        }

    }

    private void RotateAllSpells()
    {
        RotateOneSpell(BasicSpells, BasicSpellNames, ref basicPreviousSpell, out currentBasicSpell, out BasicAdditiveEffectID);
        RotateOneSpell(UtilitySpells, UtilitySpellNames, ref utilityPreviousSpell, out currentUtilitySpell, out UtilityAdditiveEffectID);
        RotateOneSpell(UltimateSpells, UltimateSpellNames, ref ultimatePreviousSpell, out currentUltimateSpell, out UltimateAdditiveEffectID);
    }
    private void CastSpell(SpellEffect spellEffect, string spellName, int additiveID)
    {
        Debug.Log($"Name: {spellName} | Additive Effect {spellEffect.SpellAdditiveEffect[additiveID]} | Effect ID: {additiveID}");
    }

    private void RotateOneSpell(Dictionary<string, SpellEffect>  Spells, List<string> SpellNames, ref string previousSpell, out string currentSpell, out int additiveEffectID)
    {
        SpellEffect spellEffect = RollSpellTable(Spells, SpellNames, previousSpell, out currentSpell);
        additiveEffectID = SpellAdditiveID(spellEffect);
        previousSpell = currentSpell;
    }

    private SpellEffect RollSpellTable(Dictionary<string, SpellEffect> spellEffects, List<string> spellNames,
        string previousSpellName, out string currentSpellName)
    {
        SpellEffect spell = new SpellEffect();
        currentSpellName = RollSpellName(spellNames, previousSpellName, out currentSpellName);
        spell = spellEffects[currentSpellName];
        return spell;


    }

    private string RollSpellName(List<string> spellNames, string previousSpellName, out string currentSpellName)
    {
        int randomNumber = Random.Range(0, spellNames.Count);
        currentSpellName = spellNames[randomNumber];


        if (currentSpellName == previousSpellName)
        {
            return currentSpellName = RollSpellName(spellNames, previousSpellName, out currentSpellName);
        }
            return currentSpellName;
        
    }

    private int SpellAdditiveID(SpellEffect rotatedSpell)
    {
        int a = Random.Range(0, rotatedSpell.SpellAdditiveEffect.Count);
        return Random.Range(0, rotatedSpell.SpellAdditiveEffect.Count);
    }

     

    public Dictionary<string, SpellEffect> BasicSpellList()
    {
        Dictionary<string, SpellEffect> basicSpellDict = new Dictionary<string, SpellEffect>();

        List<string> FireballList = new List<string>();
        FireballList.Add("Ghost");
        FireballList.Add("Cone");
        FireballList.Add("Nest");
        FireballList.Add("Chain");
        FireballList.Add("Nova");
        FireballList.Add("Volley");
        SpellEffect fireball = new SpellEffect(fireballVfx, FireballList, fireballTexture, "FirePoint");
        basicSpellDict.Add("Fireball", fireball);

        List<string> IceVolleyList = new List<string>();
        IceVolleyList.Add("Size");
        IceVolleyList.Add("Cone");
        IceVolleyList.Add("Volley");
        IceVolleyList.Add("Nova");
        SpellEffect iceVolley = new SpellEffect(iceVolleyVfx, IceVolleyList, iceVolleyTexture, "FirePoint");
        basicSpellDict.Add("IceVolley", iceVolley);

        List<string> ChainLightningList = new List<string>();
        ChainLightningList.Add("Nest");
        ChainLightningList.Add("Chain");
        ChainLightningList.Add("Cone");
        ChainLightningList.Add("Nova");
        SpellEffect chainLightning = new SpellEffect(chainLightningVfx, ChainLightningList, chainLightningTexture, "FirePoint");
        basicSpellDict.Add("ChainLightning", chainLightning);

        List<string> GlacialCascadeList = new List<string>();
        GlacialCascadeList.Add("Nova");
        GlacialCascadeList.Add("Cone");
        GlacialCascadeList.Add("Size");
        SpellEffect glacialCascade = new SpellEffect(glacialCascadeVfx, GlacialCascadeList, glacialCascadeTexture, "FirePoint");
        basicSpellDict.Add("GlacialCascade", glacialCascade);

        List<string> MagicMissilesList = new List<string>();
        MagicMissilesList.Add("Cone");
        MagicMissilesList.Add("More");
        MagicMissilesList.Add("Chain");
        SpellEffect magicMissiles = new SpellEffect(magicMissilesVfx, MagicMissilesList, magicMissilesTexture, "FirePoint");
        basicSpellDict.Add("MagicMissiles", magicMissiles);

        return basicSpellDict;

    }
    public Dictionary<string, SpellEffect> UtilitySpellList()
    {
        Dictionary<string, SpellEffect> utilitySpellDict = new Dictionary<string, SpellEffect>();
        
        List<string> IceCageList = new List<string>();
        IceCageList.Add("");
        IceCageList.Add("Size");
        IceCageList.Add("Duration");
        SpellEffect iceCage = new SpellEffect(iceCageVfx, IceCageList, iceCageTexture, "MousePosition");
        utilitySpellDict.Add("IceCage", iceCage);

        List<string> WindTunnelList = new List<string>();
        WindTunnelList.Add("StrongerWind");
        WindTunnelList.Add("Width");
        WindTunnelList.Add("Length");
        WindTunnelList.Add("PlayerSpeed");
        WindTunnelList.Add("");
        SpellEffect windTunnel = new SpellEffect(windTunnelVfx, WindTunnelList, windTunnelTexture, "FirePoint");
        utilitySpellDict.Add("WindTunnel", windTunnel);

        List<string> HurricaneList = new List<string>();
        HurricaneList.Add("Size");
        HurricaneList.Add("Pull");
        HurricaneList.Add("Nova");
        HurricaneList.Add("Cone");
        HurricaneList.Add("PlayerSpeed");
        SpellEffect hurricane = new SpellEffect(hurricaneVfx, HurricaneList, hurricaneTexture, "FirePoint");
        utilitySpellDict.Add("Hurricane", hurricane);

        Debug.Log($"HERE: {utilitySpellDict["Hurricane"].SpellAdditiveEffect[0]} ");
        List<string> StormEyeList = new List<string>();
        StormEyeList.Add("");
        SpellEffect stormEye = new SpellEffect(stormEyeVfx, StormEyeList, stormEyeTexture, "PlayerCentered");
        utilitySpellDict.Add("StormEye", stormEye);

        List<string> FlameDashList = new List<string>();
        FlameDashList.Add("Distance");
        FlameDashList.Add("Fireball");
        SpellEffect flameDash = new SpellEffect(flameDashVfx, FlameDashList, iceCageTexture, "Raycast");
        utilitySpellDict.Add("FlameDash", flameDash);

        List<string> TransposeList = new List<string>();
        TransposeList.Add("Kill");
        TransposeList.Add("PlayerSpeed");
        TransposeList.Add("");
        SpellEffect transpose = new SpellEffect(transposeVfx, TransposeList, transposeTexture, "Raycast");
        utilitySpellDict.Add("Transpose", transpose);


        return utilitySpellDict;
    }
    public Dictionary<string, SpellEffect> UltimateSpellList()
    {
        Dictionary<string, SpellEffect> ultimateSpellDict = new Dictionary<string, SpellEffect>();

        List<string> BlackholeList = new List<string>();
        BlackholeList.Add("");
        BlackholeList.Add("Radius");
        SpellEffect blackhole = new SpellEffect(blackholeVfx, BlackholeList, blackholeTexture, "PlayerCentered");
        ultimateSpellDict.Add("Blackhole", blackhole);

        List<string> IceAgeList = new List<string>();
        IceAgeList.Add("");
        IceAgeList.Add("Size");
        SpellEffect iceAge = new SpellEffect(iceAgeVfx, IceAgeList, iceAgeTexture, "PlayerCentered");
        ultimateSpellDict.Add("IceAge", iceAge);

        List<string> SwirlingNovaList = new List<string>();
        SwirlingNovaList.Add("Bounce");
        SwirlingNovaList.Add("Size");
        SwirlingNovaList.Add("PSpeed");
        SpellEffect swirlingNova = new SpellEffect(swirlingNovaVfx, SwirlingNovaList, swirlingNovaTexture, "PlayerCentered");
        ultimateSpellDict.Add("SwirlingNova", swirlingNova);

        List<string> InfiniteFireballList = new List<string>();
        InfiniteFireballList.Add("");
        SpellEffect infiniteFireball = new SpellEffect(infiniteFireballVfx, InfiniteFireballList, infiniteFireballTexture, "FirePoint");
        ultimateSpellDict.Add("InfiniteFireball", infiniteFireball);

        List<string> ConduitsList = new List<string>();
        ConduitsList.Add("Star");
        ConduitsList.Add("Pentagon");
        SpellEffect conduits = new SpellEffect(conduitsVfx, ConduitsList, conduitsTexture, "PlayerCentered");
        ultimateSpellDict.Add("Conduits", conduits);

        
        return ultimateSpellDict;
    }

    public List<string> BasicSpellNameList()
    {
        List<string> basicSpellNames = new List<string>();
        basicSpellNames.Add("Fireball");
        basicSpellNames.Add("IceVolley");
        basicSpellNames.Add("ChainLightning");
        basicSpellNames.Add("GlacialCascade");
        basicSpellNames.Add("MagicMissiles");
        return basicSpellNames;
    }
    public List<string> UtilitySpellNameList()
    {
        List<string> utilitySpellNames = new List<string>();
        utilitySpellNames.Add("IceCage");
        utilitySpellNames.Add("WindTunnel");
        utilitySpellNames.Add("Hurricane");
        utilitySpellNames.Add("StormEye");
        utilitySpellNames.Add("FlameDash");
        utilitySpellNames.Add("Transpose");
        return utilitySpellNames;
    }
    public List<string> UltimateSpellNameList()
    {
        List<string> ultimateSpellNames = new List<string>();
        ultimateSpellNames.Add("Blackhole");
        ultimateSpellNames.Add("IceAge");
        ultimateSpellNames.Add("SwirlingNova");
        ultimateSpellNames.Add("InfiniteFireball");
        ultimateSpellNames.Add("Conduits");
        return ultimateSpellNames;
    }

    public class SpellEffect
    {
        public string Name { get; private set; }
        public GameObject Vfx { get; private set; }
        public List<string> SpellAdditiveEffect { get; private set; }
        public Texture SpellPicture { get; private set; }
        public string CastType { get; private set; }

        public SpellEffect(GameObject vfx = null, List<string> spellAdditiveEffect = null, Texture spellPicture = null, string castType = "")
        {
//            Name = name;
            Vfx = vfx;
            SpellAdditiveEffect = spellAdditiveEffect;
            SpellPicture = spellPicture;
            CastType = castType;
        }

        public SpellEffect()
        { }
    }
}
