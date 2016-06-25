#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SimplePistolShootConfig : SpellConfig {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Pirate/Simple Pistol Shoot")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<SimplePistolShootConfig>();
    }
#endif

    public ShootConfig shoot;
}