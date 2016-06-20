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



    public GameObject[] walkableTiles;
    public GameObject[] unwalkableTiles;
    public GameObject[] obstacleTiles;

    public NumberRange size;
    public NumberRange unwalkable;
    public NumberRange obstacle;

    public GameObject[][] typeToPrefabList;

    public void OnEnable () {
        typeToPrefabList = new GameObject[3][];
        typeToPrefabList[(int) Tile.Type.walkable]   = walkableTiles;
        typeToPrefabList[(int) Tile.Type.unwalkable] = unwalkableTiles;
        typeToPrefabList[(int) Tile.Type.obstacle]   = obstacleTiles;
    }

}