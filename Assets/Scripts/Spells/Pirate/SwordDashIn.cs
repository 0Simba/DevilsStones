using UnityEngine;
using System.Collections;

public class SwordDashIn : Spell {

    public  GameObject        sword;
    private SwordDashInConfig config;


    new protected void Start () {
        base.Start();
        sword.SetActive(false);
        config = GeneralConfig.instance.swordDashInConfig;

        AreaDamage areaDamage       = sword.GetComponent<AreaDamage>();
        areaDamage.damagePerSeconds = config.damagePerSeconds;
    }


    protected override void Cast () {
        base.Cast();
        caster.transform.LookAt(Mouse.floorPosition);

        SetDash();
    }


    public void SetDash () {
        sword.SetActive(true);

        Vector3 finalPosition = caster.transform.position + caster.transform.forward * config.dashDistance;

        caster.SetForcedMovement(caster.transform.position, finalPosition, config.dashDuration, config.dashCurve, Deactivate);
    }


    public void Deactivate (bool interupted) {
        sword.SetActive(false);
    } 
}