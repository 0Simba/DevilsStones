using UnityEngine;
using System.Collections;

public class TwoEntityRelation {

    public Entity entityA;
    public Entity entityB;

    public float distance;


    public TwoEntityRelation (Entity entityA, Entity entityB) {
        this.entityA = entityA;
        this.entityB = entityB;

        distance = (entityA.transform.position - entityB.transform.position).magnitude;
    }
}