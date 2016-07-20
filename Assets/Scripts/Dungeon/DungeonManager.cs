using UnityEngine;
using System.Collections;

public class DungeonManager : MonoBehaviour {

    public Dungeon dungeon;

    void Awake () {
        gameObject.AddComponent<RoomLoader>();
        gameObject.AddComponent<RoomEnemies>();
    }


    void Start () {
        dungeon = new Dungeon();
        dungeon.Generate();

    }


    
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Room room = dungeon.GetRoom(Vector3.zero);

            room.Load();
        }
    }
}