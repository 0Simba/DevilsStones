using UnityEngine;
using System.Collections;

public class GoToOnClick : MonoBehaviour {

    public LayerMask    layerMask;
    public NavMeshAgent navMeshAgent;


    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

}