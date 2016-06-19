using UnityEngine;
using System.Collections;

public class Swap : Spell {


    private SwapConfig config;

    new protected void Start () {
        base.Start();
        config = GeneralConfig.instance.swapConfig;
    }


    protected override bool PreTryCast () {
        return (!EntityOverIsSelf() && InRangeOfEntityOver(config.range));
    }

    
    protected override void Cast () {
        base.Cast();

        Vector3 storedTargetPosition        = caster.transform.position;
        caster.transform.position           = Mouse.entityOver.transform.position;
        Mouse.entityOver.transform.position = storedTargetPosition;

        caster.SetDestination(caster.transform.position);
    }
}