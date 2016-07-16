#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DungeonConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Dungeon")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<DungeonConfig>();
    }
#endif


    public DiceRandom roomsNumber;
    public DiceRandom floorsNumber;
    public DiceRandom laddersNumber;
}
