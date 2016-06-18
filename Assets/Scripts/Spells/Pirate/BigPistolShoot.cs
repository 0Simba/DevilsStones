using UnityEngine;
using System.Collections;

public class BigPistolShoot : Spell {

    public GameObject bulletPrefab;
    public Transform  spawnPoint;
    public int        damage;

    protected override void Cast () {
        base.Cast();
        target.LookAt(Mouse.floorPosition);
        Instantiate(bulletPrefab, spawnPoint.position, target.rotation);
    }
}