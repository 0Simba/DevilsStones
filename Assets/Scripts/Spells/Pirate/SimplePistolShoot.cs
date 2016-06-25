using UnityEngine;
using System.Collections;

public class SimplePistolShoot : Spell {

    public  Transform               spawnPoint;
    private SimplePistolShootConfig config;


    new protected void Start () {
        base.Start();
        config = GeneralConfig.instance.simplePistolShootConfig;
        base.ApplyConfig(config);
    }


    protected override void Cast () {
        base.Cast();

        caster.transform.LookAt(Mouse.floorPosition);

        caster.Shoot(config.shoot, spawnPoint.position);
    }
}