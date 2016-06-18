using UnityEngine;
using System.Collections;

public class PowderKeg : Spell {

    private PowderKegConfig config;

    new protected void Start () {
        base.Start();
        config = GeneralConfig.instance.powderKegConfig;
    }

    protected override bool PreTryCast () {
        return InRangeOfFloorPosition(config.range);
    }


    protected override void Cast () {
        base.Cast();
        Instantiate(config.prefab, Mouse.floorPosition, Quaternion.identity);
    }
}