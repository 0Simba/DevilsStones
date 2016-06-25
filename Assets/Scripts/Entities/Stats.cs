using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    [HideInInspector] public int   life;
    [HideInInspector] public float percentDamages;
    [HideInInspector] public int   fixDamages;
    [HideInInspector] public float percentResist;
    [HideInInspector] public int   fixResist;
    [HideInInspector] public float moveSpeed;

    private Entity entity;



    void Awake () {
        entity = GetComponent<Entity>();
    }


    public void ApplyConfig (StatsConfig config) {
        ExtractValues(config);

        entity.navMeshAgent.speed = moveSpeed;
        entity.life.SetMax(life);
    }


    public void ExtractValues (StatsConfig config) {
        life           = config.life;
        percentDamages = config.percentDamages;
        fixDamages     = config.fixDamages;
        percentResist  = config.percentResist;
        fixResist      = config.fixResist;
        moveSpeed      = config.moveSpeed;
    }
}