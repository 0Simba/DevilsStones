using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    void Generate () {
        RoomGeography roomGeography = RoomGeography.CreateOnce();
        RoomLoader.Load(roomGeography);
        RoomEnemies.CreateOnce();
    }
}