using UnityEngine;
using System.Collections;

public class RoomLoader : MonoBehaviour {

    static public  GameObject        tilesParent;
    static public  RoomCreatorConfig config;
    static private RoomData          currentData;
    static private RoomLoader        instance;


    static public void Load (RoomData data) {
        config      = GeneralConfig.instance.roomCreatorConfig;
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

    void Awake () {
        instance = this;
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