using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (ForcedMovement))]
[RequireComponent (typeof (Life))]
[RequireComponent (typeof (Stats))]
public class Entity : MonoBehaviour {


    public enum Camp {
        demon,
        human,
        neutral
    }


    public delegate void HitMethod (float value);
    public delegate void DieMethod ();
    public event HitMethod OnHit;
    public event DieMethod OnDie;


    [HideInInspector] public NavMeshAgent   navMeshAgent;
    [HideInInspector] public ForcedMovement forcedMovement;
    [HideInInspector] public Life           life;
    [HideInInspector] public Stats          stats;


    public Camp        camp;
    public StatsConfig statsConfig;

    protected void Awake () {
        navMeshAgent   = GetComponent<NavMeshAgent>();
        forcedMovement = GetComponent<ForcedMovement>();
        life           = GetComponent<Life>();
        stats          = GetComponent<Stats>();

        SetEntityTag();
    }


    protected void Start () {
        EventBus.EmitEntitySpawned(this);
        stats.ApplyConfig(statsConfig);
    }


    void OnDestroy () {
        EventBus.EmitEntityDied(this);
    }


    public void SetEntityTag () {
        if (gameObject.layer != LayerMask.NameToLayer("Default") && gameObject.layer != LayerMask.NameToLayer("Entity")) {
            Debug.LogWarning("[Devil's stones] Entity.SetEntityTag -> Attached layer is different than default and entity, changed it for entity");
        }

        gameObject.layer = LayerMask.NameToLayer("Entity");
    }


    public void Hit (float damage) {
        if (OnHit != null) {
            OnHit(damage);
        }
    }


    public void Burn (float damagePerSeconds) {
        float damage = damagePerSeconds * Time.deltaTime;
        Debug.Log("burn " + damage.ToString());
        life.Lose(damage);
    }


    public void Kill () {
        if (OnDie != null) {
            OnDie();
        }

        Destroy(gameObject);
    }


    public void SetDestination (Vector3 position) {
        if (forcedMovement.isIt) {
            return;
        }

        navMeshAgent.Resume();
        navMeshAgent.SetDestination(position);
    }


    public void SetForcedMovement (Vector3 startPosition, Vector3 endPosition, float duration, AnimationCurve curve, ForcedMovement.BoolCallback callback = null) {
        navMeshAgent.Stop();
        forcedMovement.Set(startPosition, endPosition, duration, curve, callback);
    }


    public void Shoot (ShootConfig config, Vector3 spawnPoint) {
        GameObject bullet = Instantiate(config.prefab, spawnPoint,transform.rotation) as GameObject;

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.Init(config.speed, config.lifeTime, config.damage);
    }


    public virtual void HeavyUpdate () {

    }
}