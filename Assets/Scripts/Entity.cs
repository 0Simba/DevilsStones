using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (ForcedMovement))]
public class Entity : MonoBehaviour {


    public delegate void HitMethod (float value);
    public event HitMethod OnHit;

    [HideInInspector] public NavMeshAgent   navMeshAgent;
    [HideInInspector] public ForcedMovement forcedMovement;

    void Start () {
        navMeshAgent   = GetComponent<NavMeshAgent>();
        forcedMovement = GetComponent<ForcedMovement>();
        SetEntityTag();
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


    public void SetDestination (Vector3 position) {
        if (forcedMovement.isIt) {
            return;
        }

        navMeshAgent.SetDestination(position);
    }
}