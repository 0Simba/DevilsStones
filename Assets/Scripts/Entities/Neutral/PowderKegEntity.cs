using UnityEngine;
using System.Collections;

public class PowderKegEntity : Entity {

    private PowderKegConfig config;

    new protected void Start () {
        base.Start();
        config = GeneralConfig.instance.powderKegConfig;

        OnDie += Explode;
        life.SetMax(config.maxLife);
    }


    void Update () {
        Hit(config.lifeLostPerSecond * Time.deltaTime);
    }


    void Explode () {
        GameObject explosion =  Instantiate(config.explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosion.GetComponent<Explosion>().Init(config.explosionDuration, config.explosionDamage, config.explosionRange);
    }
}