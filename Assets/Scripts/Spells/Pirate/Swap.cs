using UnityEngine;
using System.Collections;

public class Swap : Spell {

    [HideInInspector] public NavMeshAgent targetNavMeshAgent;

    public float range = 10f;




    new protected void Start () {
        base.Start();
        targetNavMeshAgent = target.GetComponent<NavMeshAgent>();
    }


    protected override bool PreTryCast () {
        return (!EntityOverIsSelf() && InRangeOfEntityOver(range));
    }

    
    protected override void Cast () {
        base.Cast();

        Vector3 storedTargetPosition = target.position;
        target.position                     = Mouse.entityOver.transform.position;
        Mouse.entityOver.transform.position = storedTargetPosition;

        targetNavMeshAgent.SetDestination(target.position);
    }
}