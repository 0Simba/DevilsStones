using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    void Awake () {
        gameObject.AddComponent<RoomLoader>();
        gameObject.AddComponent<RoomEnemies>();
    }


    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Generate();
        }
    }


    void Generate () {
        RoomGeography roomGeography = RoomGeography.CreateOnce();
        RoomLoader.Load(roomGeography);
        RoomEnemies.CreateOnce();
    }
}