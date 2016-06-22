using UnityEngine;
using System;
using System.Collections;

public class RoomLoader : MonoBehaviour {

    static public  GameObject        tilesParent;
    static public  RoomCreatorConfig config;
    static private RoomGeography     currentData;
    static private RoomLoader        instance;


    static public void Load (RoomGeography data) {
        currentData = data;

        instance.Map();
    }


    static public GameObject GetGameObjectPrefab (Tile tile) {
        return config.typeToPrefabList[(int) tile.type][tile.appearence];
    }


    static public Vector3 WorldPosition (int x, int y) {
        return new Vector3(x * config.tileSize - currentData.sizeX * config.tileSize / 2, 0, y * config.tileSize - currentData.sizeY * config.tileSize / 2);
    }



    /*=====================================
    =            Instance Part            =
    =====================================*/

    public GameObject[][][] pulling; // [Tile.Type][AppearenceIndex][GameObjectInstance]
    public int[][]          cursors;



    void Awake () {
        instance = this;
    }


    void Start () {
        config = GeneralConfig.instance.roomCreatorConfig;
        CreatePullingArray();
    }


    void Map () {
        DeactivateAll();
        currentData.ForEachTile(PlaceTile);
    }


    void PlaceTile (int x, int y, Tile tile) {
        int        index    = cursors[(int) tile.type][tile.appearence];
        GameObject target   = pulling[(int) tile.type][tile.appearence][index];

        cursors[(int) tile.type][tile.appearence]++;

        target.SetActive(true);
        target.transform.position   = WorldPosition(x, y);
        target.transform.localScale = Vector3.one * config.tileSize;
    }




    void DeactivateAll() {
        for (int typeIndex = 0; typeIndex < cursors.Length; ++typeIndex) {
            for (int appearenceIndex = 0; appearenceIndex < cursors[typeIndex].Length; ++appearenceIndex) {
                while (cursors[typeIndex][appearenceIndex] > 0) {

                    int        lastIndex = cursors[typeIndex][appearenceIndex] - 1;
                    GameObject current   = pulling[typeIndex][appearenceIndex][lastIndex];

                    current.SetActive(false);
                    cursors[typeIndex][appearenceIndex]--;
                }
            }
        }
    }


    void CreatePullingArray () {
        int tileTypes = Enum.GetNames(typeof(Tile.Type)).Length;
        pulling = new GameObject[tileTypes][][];
        cursors = new int[tileTypes][];

        for (int i = 0; i < tileTypes; ++i) {
            CreatePullingForTileTypes(i);
        }
    }


    void CreatePullingForTileTypes (int typeIndex) {
        int appearences = config.typeToPrefabList[typeIndex].Length;

        pulling[typeIndex] = new GameObject[appearences][];
        cursors[typeIndex] = new int[appearences];

        int instanceToCreate = config.typeToNumberMax[typeIndex];

        for (int i = 0; i < appearences; i++) {
            cursors[typeIndex][i] = instanceToCreate;
            FillOfPrefab(typeIndex, i, instanceToCreate);
        }
    }


    void FillOfPrefab (int typeIndex, int appearenceIndex, int number) {
        pulling[typeIndex][appearenceIndex] = new GameObject[number];
        GameObject prefab = config.typeToPrefabList[typeIndex][appearenceIndex];

        for (int i = 0; i < number; ++i) {
            GameObject instanciatedPrefab = GameObject.Instantiate(prefab) as GameObject;
            pulling[typeIndex][appearenceIndex][i] = instanciatedPrefab;
        }
    }
}