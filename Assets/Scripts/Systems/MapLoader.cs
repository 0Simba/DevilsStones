using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapLoader : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject   player;

    static public RoomCreatorConfig config;


    void Awake () {
        config = GeneralConfig.instance.roomCreatorConfig;
        Instantiate(player);
    }


    void Start () {
        LoadRoom();
    }


    void LoadRoom () {
        int index = Random.Range(0, rooms.Length);
        Instantiate(rooms[index]);
    }
}