#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SwapConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Pirate/Swap")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<SwapConfig>();
    }
#endif

    
    [Header("Cast")]
    [Range(0.5f, 50)] public float      range = 1f;
}