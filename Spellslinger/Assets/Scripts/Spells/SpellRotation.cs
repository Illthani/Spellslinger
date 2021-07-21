using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpellRotation : MonoBehaviour
{
    private Dictionary<string, List<string>> spellVariationList;

    public Dictionary<string, SpellEffect> BasicSpells;
    public Dictionary<string, SpellEffect> UltimateSpells;
    public Dictionary<string, SpellEffect> UtilitySpells;
    private List<string> BasicSpellNames;
    private List<string> UltimateSpellNames;
    private List<string> UtilitySpellNames;
    private Dictionary<string, Texture> AdditiveEffectTextures;
    private Dictionary<string, Texture> SpellTextures;

    private SpellEffect basicSpellEffect;
    private SpellEffect utilitySpellEffect;
    private SpellEffect ultimateSpellEffect;

    private int BasicAdditiveEffectID;
    private int UtilityAdditiveEffectID;
    private int UltimateAdditiveEffectID;

    private string basicPreviousSpell;
    private string utilityPreviousSpell;
    private string ultimatePreviousSpell;

//    [Header("Referrence GameObjects")]
//    public GameObject AdditiveTextureCanvas;

    public Texture transperentTexture;

    [Header("Additive Textures")]
    public Texture bounceTexture;
    public Texture chainTexture;
    public Texture coneTexture;
    public Texture durationTexture;
    public Texture ghostTexture;
    public Texture inwardsTexture;
    public Texture killTexture;
    public Texture lengthTexture;
    public Texture nestTexture;
    public Texture novaTexture;
    public Texture pentagonTexture;
    public Texture sizeTexture;
    public Texture speedTexture;
    public Texture starTexture;
    public Texture strengthTexture;
    public Texture volleyTexture;
    public Texture widthTexture;
    [Header("Spell Textures")]
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
    [Header("RawImageSlots")]
    public RawImage additiveRawImageBasic;
    public RawImage additiveRawImageUtility;
    public RawImage additiveRawImageUltimate;
    public RawImage spellRawImageBasic;
    public RawImage spellRawImageUtility;
    public RawImage spellRawImageUltimate;
    public List<RawImage> cooldownsRawImages;

    private float spellTimer;
    [SerializeField] private float spellTimerMax = 1f;

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

        AdditiveEffectTextures = AdditiveTexturesFillDict();
        SpellTextures = SpellTexturesFillDict();

        RotateAllSpells();
    }

    private void Update()
    {
        spellTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (spellTimer <= 0f)
            {
                CastSpell(BasicSpells[currentBasicSpell], currentBasicSpell, BasicAdditiveEffectID);
                RotateAllSpells();
                spellTimer = spellTimerMax;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (spellTimer <= 0f)
            {
                CastSpell(UltimateSpells[currentUltimateSpell], currentUltimateSpell, UltimateAdditiveEffectID);
                RotateAllSpells();
                spellTimer = spellTimerMax;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spellTimer <= 0f)
            {
                CastSpell(UtilitySpells[currentUtilitySpell], currentUtilitySpell, UtilityAdditiveEffectID);
                RotateAllSpells();
                spellTimer = spellTimerMax;
            }
        }

    }

    private void VisualCooldownAll(float cooldown, float alphaValue)
    {
        spellRawImageBasic.CrossFadeAlpha(alphaValue, cooldown, false);
        spellRawImageUtility.CrossFadeAlpha(alphaValue, cooldown, false);
        spellRawImageUltimate.CrossFadeAlpha(alphaValue, cooldown, false);
    }

    private void RotateAllSpells()
    {
        RotateOneSpell(BasicSpells, BasicSpellNames, additiveRawImageBasic, spellRawImageBasic, ref basicPreviousSpell, out currentBasicSpell, out BasicAdditiveEffectID);
        RotateOneSpell(UtilitySpells, UtilitySpellNames, additiveRawImageUtility, spellRawImageUtility, ref utilityPreviousSpell, out currentUtilitySpell, out UtilityAdditiveEffectID);
        RotateOneSpell(UltimateSpells, UltimateSpellNames, additiveRawImageUltimate, spellRawImageUltimate, ref ultimatePreviousSpell, out currentUltimateSpell, out UltimateAdditiveEffectID);

        VisualCooldownAll(0f, 0.2f);
        foreach (RawImage image in cooldownsRawImages)
        {
            image.CrossFadeAlpha(0f, 0f, false);
        }

        Invoke("RawImageCooldownUp", 1f);
        VisualCooldownAll(1f, 1f);



    }
    private void CastSpell(SpellEffect spellEffect, string spellName, int additiveID)
    {
        Debug.Log($"Name: {spellName} | Additive Effect {spellEffect.SpellAdditiveEffect[additiveID]} | Effect ID: {additiveID}");
        string additiveEffect = spellEffect.SpellAdditiveEffect[additiveID];
        if (spellEffect != null)
        {
            gameObject.GetComponent<CastSpell>().AttemptCast(spellEffect.Vfx, additiveEffect, spellEffect.CastType);
        }
    }

    private void RawImageCooldownUp()
    {
        foreach (RawImage image in cooldownsRawImages)
        {
            image.CrossFadeAlpha(1f, 0f, false);
        }
    }

    private void RotateOneSpell(Dictionary<string, SpellEffect>  Spells, List<string> SpellNames, RawImage additiveRawImage, RawImage spellRawImage, ref string previousSpell, out string currentSpell, out int additiveEffectID)
    {
        SpellEffect spellEffect = RollSpellTable(Spells, SpellNames, previousSpell, out currentSpell);
        additiveEffectID = SpellAdditiveID(spellEffect);
        previousSpell = currentSpell;

        additiveRawImage.texture = AdditiveEffectTextures[spellEffect.SpellAdditiveEffect[additiveEffectID]];
        spellRawImage.texture = SpellTextures[currentSpell];

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
        MagicMissilesList.Add("Volley");
        MagicMissilesList.Add("Chain");
        SpellEffect magicMissiles = new SpellEffect(magicMissilesVfx, MagicMissilesList, magicMissilesTexture, "PlayerAttached");
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
        WindTunnelList.Add("Strength");
        WindTunnelList.Add("Width");
        WindTunnelList.Add("Length");
        WindTunnelList.Add("PSpeed");
        WindTunnelList.Add("");
        SpellEffect windTunnel = new SpellEffect(windTunnelVfx, WindTunnelList, windTunnelTexture, "PlayerCentered");
        utilitySpellDict.Add("WindTunnel", windTunnel);

        List<string> HurricaneList = new List<string>();
        HurricaneList.Add("Size");
        HurricaneList.Add("Inwards");
        HurricaneList.Add("Nova");
        HurricaneList.Add("Cone");
        HurricaneList.Add("PSpeed");
        SpellEffect hurricane = new SpellEffect(hurricaneVfx, HurricaneList, hurricaneTexture, "FirePoint");
        utilitySpellDict.Add("Hurricane", hurricane);

        List<string> StormEyeList = new List<string>();
        StormEyeList.Add("");
        SpellEffect stormEye = new SpellEffect(stormEyeVfx, StormEyeList, stormEyeTexture, "PlayerCentered");
        utilitySpellDict.Add("StormEye", stormEye);

        List<string> FlameDashList = new List<string>();
        FlameDashList.Add("Length");
        FlameDashList.Add("Fireball");
        SpellEffect flameDash = new SpellEffect(flameDashVfx, FlameDashList, iceCageTexture, "Raycast");
        utilitySpellDict.Add("FlameDash", flameDash);
            
        List<string> TransposeList = new List<string>();
        TransposeList.Add("Kill");
        TransposeList.Add("PSpeed");
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
        BlackholeList.Add("Size");
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

    public Dictionary<string, Texture> AdditiveTexturesFillDict()
    {
        Dictionary<string, Texture> AdditiveEffectTextures = new Dictionary<string, Texture>();
        AdditiveEffectTextures.Add("Bounce", bounceTexture);
        AdditiveEffectTextures.Add("Chain", chainTexture);
        AdditiveEffectTextures.Add("Cone", coneTexture);
        AdditiveEffectTextures.Add("Duration", durationTexture);
        AdditiveEffectTextures.Add("Ghost", ghostTexture);
        AdditiveEffectTextures.Add("Inwards", inwardsTexture);
        AdditiveEffectTextures.Add("Kill", killTexture);
        AdditiveEffectTextures.Add("Length", lengthTexture);
        AdditiveEffectTextures.Add("Nest", nestTexture);
        AdditiveEffectTextures.Add("Nova", novaTexture);
        AdditiveEffectTextures.Add("Pentagon", pentagonTexture);
        AdditiveEffectTextures.Add("Size", sizeTexture);
        AdditiveEffectTextures.Add("PSpeed", speedTexture);
        AdditiveEffectTextures.Add("Star", starTexture);
        AdditiveEffectTextures.Add("Strength", strengthTexture);
        AdditiveEffectTextures.Add("Volley", volleyTexture);
        AdditiveEffectTextures.Add("Width", widthTexture);
        AdditiveEffectTextures.Add("Fireball", fireballTexture);
        AdditiveEffectTextures.Add("", transperentTexture);
        return AdditiveEffectTextures;
    }
    public Dictionary<string, Texture> SpellTexturesFillDict()
    {
        Dictionary<string, Texture> AdditiveEffectTextures = new Dictionary<string, Texture>();
        AdditiveEffectTextures.Add("Fireball", fireballTexture);
        AdditiveEffectTextures.Add("IceVolley", iceVolleyTexture);
        AdditiveEffectTextures.Add("Blackhole", blackholeTexture);
        AdditiveEffectTextures.Add("ChainLightning", chainLightningTexture);
        AdditiveEffectTextures.Add("IceCage", iceCageTexture);
        AdditiveEffectTextures.Add("IceAge", iceAgeTexture);
        AdditiveEffectTextures.Add("WindTunnel", windTunnelTexture);
        AdditiveEffectTextures.Add("Hurricane", hurricaneTexture);
        AdditiveEffectTextures.Add("SwirlingNova", swirlingNovaTexture);
        AdditiveEffectTextures.Add("StormEye", stormEyeTexture);
        AdditiveEffectTextures.Add("GlacialCascade", glacialCascadeTexture);
        AdditiveEffectTextures.Add("FlameDash", flameDashTexture);
        AdditiveEffectTextures.Add("Transpose", transposeTexture);
        AdditiveEffectTextures.Add("MagicMissiles", magicMissilesTexture);
        AdditiveEffectTextures.Add("InfiniteFireball", infiniteFireballTexture);
        AdditiveEffectTextures.Add("Conduits", conduitsTexture);
        AdditiveEffectTextures.Add("", transperentTexture);
        return AdditiveEffectTextures;
    }

    public class SpellEffect
    {
//        public string Name { get; private set; }
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