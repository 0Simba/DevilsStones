#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SwordDashInConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Sword Dash In")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<SwordDashInConfig>();
    }
#endif

    
    [Range(1, 1000)]  public float          damage;
    [Range(0.5f, 20)] public float          dashDistance;
    [Range(0.01f, 2)] public float          dashDuration;
                      public AnimationCurve dashCurve;
}