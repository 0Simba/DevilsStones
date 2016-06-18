using UnityEngine;
using System.Collections;

public class PowderKeg : Spell {

    public GameObject powderKegPrefab;
    public float      range = 1f;


    protected override bool PreTryCast () {
        return SpellHelper.CastedInRange(target.position, range);
    }


    protected override void Cast () {
        base.Cast();
        Instantiate(powderKegPrefab, Mouse.floorPosition, Quaternion.identity);
    }
}