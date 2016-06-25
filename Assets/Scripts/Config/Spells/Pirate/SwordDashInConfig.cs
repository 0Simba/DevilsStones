#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SwordDashInConfig : SpellConfig {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Pirate/Sword Dash In")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<SwordDashInConfig>();
    }
#endif

    
    [Range(1, 9999)]  public float          damagePerSeconds;
    [Range(0.5f, 20)] public float          dashDistance;
    [Range(0.01f, 2)] public float          dashDuration;
                      public AnimationCurve dashCurve;
}