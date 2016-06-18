using UnityEngine;
using System.Collections;

public abstract class Spell : MonoBehaviour {

    [HideInInspector] public float currentTime = 0;
    [HideInInspector] public bool  isSmartCast = true;


    public    float      castCost      = 1;
    public    float      overCostValue = 2.5f;
    public    float      cantCastValue = 5;
    public    KeyCode    key;
    public    GameObject preview;
    public    Entity     caster;

    protected bool       isSelected = false;


    protected bool EntityOverIsSelf () {
        return (Mouse.entityOver != null && caster == Mouse.entityOver);
    }

    protected virtual bool PreTryCast () {
        return true;
    }


    protected virtual void Cast () {
        currentTime += castCost;
    }


    protected void Start () {
        EventBus.overCostSpellCasted += OnOverCostSpellCasted;
    }


    protected bool InRangeOfFloorPosition (float range) {
        if (!Mouse.isOverFloor) {
            return false;
        }

        return IsPointsClosestThan(caster.transform.position, Mouse.floorPosition, range);
    }


    protected bool InRangeOfEntityOver (float range) {
        if (!Mouse.isOverEntity) {
            return false;
        }

        return IsPointsClosestThan(caster.transform.position, Mouse.entityOver.transform.position, range);
    }


    protected bool IsPointsClosestThan (Vector3 pointA, Vector3 pointB, float distance) {
        return ((pointA - pointB).magnitude <= distance);
    }


    void Update () {
        currentTime = Mathf.Max(currentTime - Time.deltaTime, 0);
        if (Input.GetKeyDown(key)) {
            SpellKeyPressed();
        }
    }


    void SpellKeyPressed () {
        if (isSmartCast) {
            TryCast();
        }
        else {
            // Add code here
        }
    }


    void TryCast () {
        if (!PreTryCast()) {
            return;
        }

        if (currentTime >= cantCastValue) {
            return;
        }


        if (currentTime >= overCostValue) {
            EventBus.EmitOverCostSpellCasted(castCost);
        }

        Cast();
    }


    void OnDestroy () {
        EventBus.overCostSpellCasted -= OnOverCostSpellCasted;
    }


    void OnOverCostSpellCasted (float cost) {
        currentTime += cost;
    }
}