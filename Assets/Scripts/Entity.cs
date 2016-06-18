using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (ForcedMovement))]
[RequireComponent (typeof (Life))]
public class Entity : MonoBehaviour {


    public delegate void HitMethod (float value);
    public delegate void DieMethod ();
    public event HitMethod OnHit;
    public event DieMethod OnDie;


    [HideInInspector] protected NavMeshAgent   navMeshAgent;
    [HideInInspector] protected ForcedMovement forcedMovement;
    [HideInInspector] public    Life           life;


    void Awake () {
        navMeshAgent   = GetComponent<NavMeshAgent>();
        forcedMovement = GetComponent<ForcedMovement>();
        life           = GetComponent<Life>();
        SetEntityTag();        
    }


    void Start () {
        EventBus.EmitEntitySpawned(this);
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


    public void SetForcedMovement (Vector3 startPosition, Vector3 endPosition, float duration, AnimationCurve curve) {
        navMeshAgent.Stop();
        forcedMovement.Set(startPosition, endPosition, duration, curve);
    }
}