#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemiesGroupConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Rooms/Enemies Group")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<EnemiesGroupConfig>();
    }
#endif


    public NumberRange difficulty;

    [Range(1, 100)]  public int patternChallenge;


    public GameObject[] enemies;
}