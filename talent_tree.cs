using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talent_tree : MonoBehaviour
{

    public float lightningMult = 2.0f;
    public float chainLightningRangeMult = 2.0f;
    public float fireballMult = 2.0f;
    public float fireballRadMult = 2.0f;

    public GameObject lightningSpellObj;
    public GameObject fireballSpellObj;
    public GameObject fireballRMBSpellObj;
    public GameObject waveController;
    public GameObject spellSwitcher;
    public GameObject fireSpells;
    
    Lightning_spell lightning;
    chain_lightning chainLightningTalent, chainLightning;
    fireball_spell fireballLMB;
    big_fireballExplosion fireballRMB;
    wave_controller tPoints;
    spell_switching spellActivation;
    fb_instantiate fbSpell;
    cast_bigFireball bigFbSpell;

    // Start is called before the first frame update
    void Start()
    {
        lightning = lightningSpellObj.GetComponent<Lightning_spell>();
        chainLightning = lightningSpellObj.GetComponent<chain_lightning>();
        chainLightningTalent = lightningSpellObj.GetComponent<chain_lightning>();
        fireballLMB = fireballSpellObj.GetComponent<fireball_spell>();
        fireballRMB = fireballRMBSpellObj.GetComponent<big_fireballExplosion>();
        tPoints = waveController.GetComponent<wave_controller>();
        spellActivation = spellSwitcher.GetComponent<spell_switching>();
        fbSpell = fireSpells.GetComponent<fb_instantiate>();
        bigFbSpell = fireSpells.GetComponent<cast_bigFireball>();
    }

    public void IncreaseLightningDamage()
    {
        if(tPoints.talentPoints > 0)
        {
            lightning.IncreaseDamage(lightningMult);
            tPoints.talentPoints--;
        }
    }

    public void IncreaseChaingLightningRange()
    {
        if(tPoints.talentPoints > 0)
        {
            chainLightning.IncreaseRange(chainLightningRangeMult);
            tPoints.talentPoints--;
        }
    }

    public void IncreaseFBLMBDamage()
    {
        if(tPoints.talentPoints > 0)
        {
            fireballLMB.IncreaseDamage(fireballMult);
            tPoints.talentPoints--;
        }
    }

    public void IncreaseFBRMBDamage()
    {
        if(tPoints.talentPoints > 0)
        {
            fireballRMB.IncreaseDamage(fireballMult);
            tPoints.talentPoints--;
        }
    }

    public void IncreaseExplosionRadius()
    {
        if(tPoints.talentPoints > 0)
        {
            fireballRMB.IncreaseRadius(fireballRadMult);
            tPoints.talentPoints--;
        }
    }

    public void ChainLightningAddTalent()
    {
        if(tPoints.talentPoints > 0)
        {
            chainLightningTalent.ActivateChainLightning();
            tPoints.talentPoints--;
        }
    }

    public void FireBallAddTalent()
    {
        if(tPoints.talentPoints > 0)
        {
            spellActivation.AddFireBallSpell();
            fbSpell.ActivateFB();
            tPoints.talentPoints--;
        }
    }

    public void FireBallExplosionAddTalent()
    {
        if(tPoints.talentPoints > 0)
        {
            spellActivation.AddRightClickFireBallSpell();
            bigFbSpell.ActivateBigFireball();
            tPoints.talentPoints--;
        }
    }



}
