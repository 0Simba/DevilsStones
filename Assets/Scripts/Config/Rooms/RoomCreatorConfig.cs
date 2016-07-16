#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RoomCreatorConfig : ScriptableObject {

#if UNITY_EDITOR
    [MenuItem("Assets/Create Config/Rooms/Room Creator")]
    private static void CreateSoFile () {
        ScriptableObjectUtility.CreateAsset<RoomCreatorConfig>();
    }
#endif


    [Header("Geography")]
    public GameObject[] walkableTiles;
    public GameObject[] unwalkableTiles;
    public GameObject[] obstacleTiles;

    public GameObject[] doorsTiles;

    public NumberRange mapSize;
    public NumberRange unwalkable;
    public NumberRange obstacle;

    [Range(1, 10)] public float tileSize;



    [HideInInspector] public GameObject[][] typeToPrefabList;
    [HideInInspector] public int[]          typeToNumberMax;

    public void OnEnable () {
        typeToPrefabList = new GameObject[4][];
        typeToPrefabList[(int) Tile.Type.walkable]   = walkableTiles;
        typeToPrefabList[(int) Tile.Type.unwalkable] = unwalkableTiles;
        typeToPrefabList[(int) Tile.Type.obstacle]   = obstacleTiles;
        typeToPrefabList[(int) Tile.Type.door]       = doorsTiles;


        typeToNumberMax = new int[4];
        typeToNumberMax[(int) Tile.Type.walkable]   = mapSize.max * mapSize.max - unwalkable.min - obstacle.min;
        typeToNumberMax[(int) Tile.Type.unwalkable] = unwalkable.max;
        typeToNumberMax[(int) Tile.Type.obstacle]   = obstacle.max;
        typeToNumberMax[(int) Tile.Type.door]       = 4;
    }


    [Header("Enemies")]
    public EnemiesGroupConfig[] enemiesGroup;
    public int                  challengeMinimumPerRoom;
}