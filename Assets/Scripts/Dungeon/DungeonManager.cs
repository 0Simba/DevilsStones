using UnityEngine;
using System.Collections;

public class DungeonManager : MonoBehaviour {

    void Awake () {
        gameObject.AddComponent<RoomManager>();
        gameObject.AddComponent<RoomLoader>();
        gameObject.AddComponent<RoomEnemies>();
    }


    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Dungeon dungeon = new Dungeon();
            dungeon.Generate();
        }
    }


}