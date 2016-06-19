#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BigPistolShotConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Spell/Big Pistol Shot")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<BigPistolShotConfig> ();
    }
#endif

    
    [Header("Shot Back")]
    [Range(0.5f, 30f)] public float          shotBackDistance = 5;
    [Range(0.01f, 5f)] public float          shotBackDuration = 0.2f;
                       public AnimationCurve shotBackCurve;



    [Header("Bullet")]
    [Range(1f, 100f)]   public float      bulletSpeed    = 20;
    [Range(0.1f, 100f)] public float      bulletLifeTime = 2;
    [Range(1, 100f)]    public float      bulletDamage   = 10;        
                        public GameObject bulletPrefab;
}