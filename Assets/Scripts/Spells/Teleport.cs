using UnityEngine;
using System.Collections;

public class Teleport : Spell {

    public NavMeshAgent targetNavMeshAgent;

    new protected void Start () {
        base.Start();
        targetNavMeshAgent = target.GetComponent<NavMeshAgent>();
    }


    protected override bool PreTryCast () {
        return Mouse.isOverFloor;
    }

    
    protected override void Cast () {
        base.Cast();
        target.position = Mouse.floorPosition;
        targetNavMeshAgent.SetDestination(Mouse.floorPosition);
    }
}