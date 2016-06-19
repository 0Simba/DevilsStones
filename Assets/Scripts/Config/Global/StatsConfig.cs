#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StatsConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Global/Stats")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<StatsConfig>();
    }
#endif

    [Range(0, 9999)] public int   life           = 100;
    [Range(0, 10)]   public float percentDamages = 0f;
    [Range(0, 1000)] public int   fixDamages     = 0;
    [Range(0, 10)]   public float percentResist  = 0f;
    [Range(0, 1000)] public int   fixResist      = 0;
    [Range(1, 100)]  public float moveSpeed      = 15;
}