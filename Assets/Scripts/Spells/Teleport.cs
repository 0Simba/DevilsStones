using UnityEngine;
using System.Collections;

public class Teleport : Spell {

    public NavMeshAgent targetNavMeshAgent;

    new protected void Start () {
        base.Start();
        targetNavMeshAgent = caster.GetComponent<NavMeshAgent>();
    }


    protected override bool PreTryCast () {
        return Mouse.isOverFloor;
    }

    
    protected override void Cast () {
        base.Cast();
        caster.transform.position = Mouse.floorPosition;
        targetNavMeshAgent.SetDestination(Mouse.floorPosition);
    }
}