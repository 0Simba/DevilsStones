using UnityEngine;
using System.Collections;

public class BigPistolShoot : Spell {

    public  Transform           spawnPoint;
    private BigPistolShotConfig config;


    new protected void Start () {
        base.Start();
        config = GeneralConfig.instance.bigPistolShotConfig;
    }


    protected override void Cast () {
        base.Cast();

        caster.transform.LookAt(Mouse.floorPosition);

        GameObject bullet = Instantiate(config.bulletPrefab, spawnPoint.position, caster.transform.rotation) as GameObject;

        bullet.GetComponent<Bullet>().Init(config.bulletSpeed, config.bulletLifeTime, config.bulletDamage);

        SetShotBack();
    }


    void SetShotBack () {
        Vector3 back          = caster.transform.forward * -1;
        Vector3 finalPosition = caster.transform.position + back * config.shotBackDistance;

        caster.SetForcedMovement(caster.transform.position, finalPosition, config.shotBackDuration, config.shotBackCurve);
    }
}