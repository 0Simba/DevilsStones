using UnityEngine;
using System.Collections;

public class GoToOnClick : MonoBehaviour {

    public LayerMask    layerMask;
    public NavMeshAgent navMeshAgent;


    void Update() {
        if (Input.GetMouseButton(0) && Mouse.isOverFloor) {
            navMeshAgent.SetDestination(Mouse.floorPosition);
        }
    }

}