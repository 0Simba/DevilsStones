using UnityEngine;
using System;
using System.Collections;

public class RoomLoader : MonoBehaviour {

    static public  GameObject        tilesParent;
    static public  RoomCreatorConfig config;
    static private RoomData          currentData;
    static private RoomLoader        instance;


    static public void Load (RoomData data) {
        currentData = data;

        instance.AsyncLoad();
    }


    static public GameObject GetGameObjectPrefab (Tile tile) {
        return config.typeToPrefabList[(int) tile.type][tile.appearence];
    }


    static public Vector3 WorldPosition (int x, int y) {
        return new Vector3(x - currentData.sizeX / 2, 0, y - currentData.sizeY);
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


    void CreatePullingArray () {
        int tileTypes = Enum.GetNames(typeof(Tile.Type)).Length;
        pulling = new GameObject[tileTypes][][];

        for (int i = 0; i < tileTypes; ++i) {
            CreatePullingForTileTypes(i);
        }
    }


    void CreatePullingForTileTypes (int typeIndex) {
        int appearences = config.typeToPrefabList[typeIndex].Length;

        pulling[typeIndex] = new GameObject[appearences][];

        int instanceToCreate = config.typeToNumberMax[typeIndex];

        for (int i = 0; i < appearences; i++) {
            FillOfPrefab(pulling[typeIndex][i], instanceToCreate, config.typeToPrefabList[typeIndex][i]);
        }
    }


    void FillOfPrefab (GameObject[] array, int number, GameObject prefab) {
        array = new GameObject[number];

        for (int i = 0; i < number; ++i) {
            GameObject instanciatedPrefab = GameObject.Instantiate(prefab) as GameObject;
            array[i] = instanciatedPrefab;
        }
    }


    public void AsyncLoad () {
        VoidChilds();
        StartCoroutine(LoadCoroutine());
    }


    public void VoidChilds () {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }


    private IEnumerator LoadCoroutine () {
        for (int x = 0; x < currentData.sizeX; ++x) {
            for (int y = 0; y < currentData.sizeY; ++y) {
                Spawn(x, y, currentData.tiles[x, y]);
                yield return null;
            }
        }
    }


    public void Spawn (int x, int y, Tile tile) {
        Vector3 position = WorldPosition(x, y);
        GameObject instiatedTile = GameObject.Instantiate(GetGameObjectPrefab(tile), position, Quaternion.identity) as GameObject;

        instiatedTile.transform.SetParent(transform);
    }


}