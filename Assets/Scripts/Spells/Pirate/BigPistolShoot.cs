using UnityEngine;
using System.Collections;

public class BigPistolShoot : Spell {

    public GameObject     bulletPrefab;
    public Transform      spawnPoint;
    public int            damage;
    public float          shotBackDistance;
    public AnimationCurve shotBackCurve;
    public float          shotBackDuration;


    protected override void Cast () {
        base.Cast();
        caster.transform.LookAt(Mouse.floorPosition);
        Instantiate(bulletPrefab, spawnPoint.position, caster.transform.rotation);

        SetShotBack();
    }


    void SetShotBack () {
        Vector3 back = caster.transform.forward * -1;
        Vector3 finalPosition = caster.transform.position + back * shotBackDistance;

        caster.SetForcedMovement(caster.transform.position, finalPosition, shotBackDuration, shotBackCurve);
    }
}