#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PowderKegConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Powder Keg")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<PowderKegConfig>();
    }
#endif

    
    [Header("Cast")]
    [Range(0.5f, 50)] public float      range = 1f;
                      public GameObject prefab;


    [Header("Instance")]
    [Range(0, 100)] public float      lifeLostPerSecond = 1.5f;
    [Range(0, 100)] public float      maxLife           = 5f;
                    public GameObject explosionPrefab;

    [Header("Explosion")]
    [Range(0.01f, 100)] public float explosionDuration = 0.5f;
    [Range(1, 1000)]    public float explosionDamage   = 5;
    [Range(0.5f, 50)]   public float explosionRange    = 5;

}