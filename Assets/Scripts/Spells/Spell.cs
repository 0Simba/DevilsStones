using UnityEngine;
using System.Collections;

public abstract class Spell : MonoBehaviour {

    [HideInInspector] public float currentTime = 0;
    [HideInInspector] public bool  isSmartCast = true;


    public    float      castCost        = 1;
    public    float      overCostValue   = 2.5f;
    public    float      surchargedValue = 5;
    public    KeyCode    key;
    public    GameObject preview;
    public    Transform  target;

    protected bool       isSelected = false;



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

        if (currentTime >= surchargedValue) {
            return;
        }

        Cast();

        if (currentTime >= overCostValue) {
            EventBus.EmitOverCostSpellCasted(castCost);
        }
    }


    protected virtual bool PreTryCast () {
        return true;
    }


    protected virtual void Cast () {
        currentTime += castCost;
    }


    void Start () {
        EventBus.overCostSpellCasted += OnOverCostSpellCasted;
    }


    void OnDestroy () {
        EventBus.overCostSpellCasted -= OnOverCostSpellCasted;
    }


    void OnOverCostSpellCasted (float cost) {
        currentTime += cost;
    }
}