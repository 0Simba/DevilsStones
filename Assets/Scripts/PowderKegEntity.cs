using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Entity))]
public class PowderKegEntity : MonoBehaviour {

    private Entity          entity;
    private PowderKegConfig config;

    void Start () {
        config = GeneralConfig.instance.powderKegConfig;

        entity = GetComponent<Entity>();
        entity.OnDie += Explode;
        entity.life.SetMax(config.maxLife);
    }


    void Update () {
        entity.Hit(config.lifeLostPerSecond * Time.deltaTime);
    }


    void Explode () {
        GameObject explosion =  Instantiate(config.explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosion.GetComponent<Explosion>().Init(config.explosionDuration, config.explosionDamage, config.explosionRange);
    }
}