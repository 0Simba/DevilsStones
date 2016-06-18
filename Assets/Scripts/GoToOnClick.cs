using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Entity))]
public class GoToOnClick : MonoBehaviour {

    public  LayerMask layerMask;
    private Entity    entity;


    void Start () {
        entity = GetComponent<Entity>();
    }


    void Update() {
        if (Input.GetMouseButton(0) && Mouse.isOverFloor) {
            entity.SetDestination(Mouse.floorPosition);
        }
    }

}