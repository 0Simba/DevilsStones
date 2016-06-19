#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ImpConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Enemies/Imp")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<ImpConfig>();
    }
#endif

    
    [Range(0, 100)]   public float       runAwayDistance  = 3;
    [Range(0, 100)]   public float       approachDistance = 10;
    [Range(0.1f, 10)] public float       attackFrequency  = 1f;
                      public ShootConfig shoot;
                      public StatsConfig stats;
}