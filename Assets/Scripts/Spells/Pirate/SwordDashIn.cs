using UnityEngine;
using System.Collections;

public class SwordDashIn : Spell {

    public float          damage;
    public float          dashDistance;
    public AnimationCurve dashCurve;
    public float          dashDuration;


    protected override void Cast () {
        base.Cast();
        caster.transform.LookAt(Mouse.floorPosition);

        SetDash();
    }


    public void SetDash () {
        Vector3 finalPosition = caster.transform.position + caster.transform.forward * dashDistance;

        caster.SetForcedMovement(caster.transform.position, finalPosition, dashDuration, dashCurve);
    }
}