using UnityEngine;
using System.Collections;

public class SwordDashIn : Spell {

    private SwordDashInConfig config;

    new protected void Start () {
        base.Start();
        config = GeneralConfig.instance.swordDashInConfig;
    }

    protected override void Cast () {
        base.Cast();
        caster.transform.LookAt(Mouse.floorPosition);

        SetDash();
    }


    public void SetDash () {
        Vector3 finalPosition = caster.transform.position + caster.transform.forward * config.dashDistance;

        caster.SetForcedMovement(caster.transform.position, finalPosition, config.dashDuration, config.dashCurve);
    }
}