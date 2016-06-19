#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ShootConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Global/Shoot")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<ShootConfig>();
    }
#endif

    [Range(1, 1000)]  public float       damage;
    [Range(1, 1000)]  public float       speed;
    [Range(1, 1000)]  public float       lifeTime;
                      public GameObject  prefab;
}
