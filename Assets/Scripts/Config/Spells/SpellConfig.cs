#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


abstract public class SpellConfig : ScriptableObject {

    [Range(0.1f, 99) ] public float castCost      = 1;
    [Range(0.1f, 99) ] public float overCostValue = 2.5f;
    [Range(0.1f, 99) ] public float cantCastValue = 5;
    [Range(0, 99) ]    public float cooldown      = 0.1f;
}