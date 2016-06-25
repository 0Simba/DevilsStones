#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BigPistolShotConfig : SpellConfig {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Pirate/Big Pistol Shot")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<BigPistolShotConfig> ();
    }
#endif

    
    [Range(0.5f, 30f)] public float shotBackDistance = 5;
    [Range(0.01f, 5f)] public float shotBackDuration = 0.2f;

    public AnimationCurve shotBackCurve;

    public ShootConfig shoot;
}