using UnityEngine;
using System.Collections;

public class PowderKeg : Spell {

    public GameObject powderKegPrefab;
    public float      range = 1f;


    protected override bool PreTryCast () {
        return InRangeOfFloorPosition(range);
    }


    protected override void Cast () {
        base.Cast();
        Instantiate(powderKegPrefab, Mouse.floorPosition, Quaternion.identity);
    }
}